using System;
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

    [Header("Dependencies")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem bloodParticle;
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float fadeDuration = 2f;

    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private RectTransform joyHandle;
    [SerializeField] private Animator animator;

    private Vector2 moveDirection;

    private void Start()
    {
        currentHealth = maxHealth;
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void FixedUpdate()
    {
        HandleMovementInput();
        MovePlayer();
    }

    private void HandleMovementInput()
    {
        moveDirection = new Vector2(joystick.Horizontal, joystick.Vertical).normalized; 
    }

    private void MovePlayer()
    {
        if (!isKnockedBack)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.fixedDeltaTime, moveDirection.y * moveSpeed * Time.fixedDeltaTime);

            if (moveDirection.magnitude > 0.1f)
            {
                transform.up = moveDirection;
            }
        }
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
            joyHandle.anchoredPosition = Vector2.zero;
            moveSpeed = 0;
            joystick.enabled = false;
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
        float flashDuration = .6f;
        float flashInterval = 0.1f;

        for (float t = 0; t < flashDuration; t += flashInterval)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flashInterval);
        }

        spriteRenderer.enabled = true;
        invincibility = false;
        Debug.Log("Player is no longer invincible.");
    }

    public void ApplyKnockback(Vector2 knockbackDirection, float knockbackForce)
    {
        if (isKnockedBack) return;
        if (invincibility) return;
        rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        StartCoroutine(KnockbackCoroutine());
    }

    private IEnumerator KnockbackCoroutine()
    {
        isKnockedBack = true;
        yield return new WaitForSeconds(knockbackDuration);
        isKnockedBack = false;
    }

    private IEnumerator FadeInText(float duration)
    {
        float targetAlpha = 1f;
        float startAlpha = 0f;
        float time = 0f;

        Debug.Log("started fade");
        while (time < duration)
        {
            time += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            SetTextAlpha(newAlpha);
            yield return null;
        }

        SetTextAlpha(targetAlpha);
        Debug.Log("faded in");
    }

    private void SetTextAlpha(float alpha)
    {
        Color color = tmpText.color;
        color.a = alpha;
        tmpText.color = color;
    }
}