using System.Collections;
using System.Xml;
using TMPro;
using UnityEngine;

[SelectionBase]
public class Player_Controller : MonoBehaviour
{
    [Header("Attributes")]
    public int maxHealth = 100;
    public int currentHealth;
    public bool invincibility = false;

    private bool isKnockedBack;
    private float knockbackDuration = 0.2f;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float dashSpeed = 1000f;
    [SerializeField] private float dashDuration = 0.1f;
    [SerializeField] private float dashCooldown = 1f;

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem bloodParticle;
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float fadeDuration = 2f;

    [SerializeField] private FixedJoystick joystick; // Joystick input reference
    [SerializeField] private Animator animator; // Animator for player animation

    private Vector2 moveDirection;
    private bool isDashing;
    private float dashEndTime;
    private float nextDashTime;

    private void Start()
    {
        currentHealth = maxHealth;
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        HandleDashingInput();
    }

    private void FixedUpdate()
    {
        HandleMovementInput();
        MovePlayer();
        HandleDashEnd();
    }

    private void HandleMovementInput()
    {
        moveDirection = new Vector2(joystick.Horizontal, joystick.Vertical).normalized; 
    }

    private void HandleDashingInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextDashTime)
        {
            StartDash();
        }
    }

    private void MovePlayer()
    {
        if (!isKnockedBack)
        {
            float speed = isDashing ? dashSpeed : moveSpeed;
            rb.velocity = new Vector2(moveDirection.x * speed * Time.fixedDeltaTime, moveDirection.y * speed * Time.fixedDeltaTime); // Updated to 2D movement

            if (moveDirection.magnitude > 0.1f)
            {
                // Rotate player towards the direction of movement
                transform.up = moveDirection; // This will rotate the sprite to face the direction of movement

            }
            else
            {

            }
        }
    }

    private void HandleDashEnd()
    {
        if (isDashing && Time.time >= dashEndTime)
        {
            isDashing = false;
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashEndTime = Time.time + dashDuration;
        nextDashTime = Time.time + dashCooldown;
    }

    public void TakeDamage(int damageAmount)
    {
        if (invincibility)
        {
            Debug.Log("Player is invincible and took no damage.");
            return;
        }

        currentHealth -= damageAmount;
        Debug.Log("Player Health: " + currentHealth);

        invincibility = true;
        StartCoroutine(InvincibilityCoroutine());

        if (currentHealth <= 0)
        {
            Debug.Log("Player Died");
            StartCoroutine(FadeInText(fadeDuration));
        }
    }

    public void PlayBloodParticle(Vector2 hitPosition)
    {
        GameObject particleObject = Instantiate(bloodParticle.gameObject, hitPosition, Quaternion.identity);

        ParticleSystem ps = particleObject.GetComponent<ParticleSystem>();

        if (ps != null)
        {
            ps.Play();
        }
    }

    private IEnumerator InvincibilityCoroutine()
    {
        float flashDuration = .6f; // Duration of invincibility effect
        float flashInterval = 0.1f; // Time between flashes

        for (float t = 0; t < flashDuration; t += flashInterval)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Toggle sprite visibility
            yield return new WaitForSeconds(flashInterval);
        }

        spriteRenderer.enabled = true; // Ensure sprite is visible at the end of the invincibility
        invincibility = false;
        Debug.Log("Player is no longer invincible.");
    }

    public void ApplyKnockback(Vector2 knockbackDirection, float knockbackForce)
    {
        if (isKnockedBack) return; // Prevent applying knockback if already knocked back
        if (invincibility) return;
        rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        isKnockedBack = true;
        yield return new WaitForSeconds(knockbackDuration); // Adjust knockback duration
        isKnockedBack = false;
    }

    private IEnumerator FadeInText(float duration)
    {
        float targetAlpha = 1f; // Target alpha (fully opaque)
        float startAlpha = 0f; // Start alpha (fully transparent)
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration); // Interpolate alpha
            SetTextAlpha(newAlpha); // Set the new alpha value
            yield return null; // Wait for the next frame
        }

        SetTextAlpha(targetAlpha); // Ensure the final alpha is set to 1
    }

    private void SetTextAlpha(float alpha)
    {
        Color color = tmpText.color;
        color.a = alpha; // Set the new alpha value
        tmpText.color = color; // Apply the new color back to the text
    }
}