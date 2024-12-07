using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonPresshard2 : MonoBehaviour
{
    [SerializeField] private Sprite buttonPressed;
    [SerializeField] private Sprite buttonUnPressed;

    [SerializeField] public Tilemap tilemap;
    [SerializeField] public TileBase tileToPlace;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") ||collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Button Pressed");
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressed;

            tilemap.SetTile(new Vector3Int(0, -15, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -16, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -17, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -18, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -19, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -20, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -21, 0), tileToPlace);

            tilemap.SetTile(new Vector3Int(-1, -15, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -16, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -17, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -18, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -19, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -20, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -21, 0), tileToPlace);
            

            tilemap.SetTile(new Vector3Int(-2, -15, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -16, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -17, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -18, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -19, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -20, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -21, 0), tileToPlace);
            



        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Button Released");
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonUnPressed;


            tilemap.SetTile(new Vector3Int(0, -15, 0), null);
            tilemap.SetTile(new Vector3Int(0, -16, 0), null);
            tilemap.SetTile(new Vector3Int(0, -17, 0), null);
            tilemap.SetTile(new Vector3Int(0, -18, 0), null);
            tilemap.SetTile(new Vector3Int(0, -19, 0), null);
            tilemap.SetTile(new Vector3Int(0, -20, 0), null);
            tilemap.SetTile(new Vector3Int(0, -21, 0), null);

            tilemap.SetTile(new Vector3Int(-1, -15, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -16, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -17, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -18, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -19, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -20, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -21, 0), null);


            tilemap.SetTile(new Vector3Int(-2, -15, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -16, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -17, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -18, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -19, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -20, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -21, 0), null);
        }
    }

}
