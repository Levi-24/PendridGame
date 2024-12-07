using UnityEngine;
using UnityEngine.Tilemaps;

public class ButtonPresshard1 : MonoBehaviour
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

            tilemap.SetTile(new Vector3Int(0, -30, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -31, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -32, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -33, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -34, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -35, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -36, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(0, -37, 0), tileToPlace);

            tilemap.SetTile(new Vector3Int(-1, -30, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -31, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -32, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -33, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -34, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -35, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -36, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-1, -37, 0), tileToPlace);


            tilemap.SetTile(new Vector3Int(-2, -30, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -31, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -32, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -33, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -34, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -35, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -36, 0), tileToPlace);
            tilemap.SetTile(new Vector3Int(-2, -37, 0), tileToPlace);



        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
        {
            Debug.Log("Button Released");
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonUnPressed;

           
            tilemap.SetTile(new Vector3Int(0, -30, 0), null);
            tilemap.SetTile(new Vector3Int(0, -31, 0), null);
            tilemap.SetTile(new Vector3Int(0, -32, 0), null);
            tilemap.SetTile(new Vector3Int(0, -33, 0), null);
            tilemap.SetTile(new Vector3Int(0, -34, 0), null);
            tilemap.SetTile(new Vector3Int(0, -35, 0), null);
            tilemap.SetTile(new Vector3Int(0, -36, 0), null);
            tilemap.SetTile(new Vector3Int(0, -37, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -30, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -31, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -32, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -33, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -34, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -35, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -36, 0), null);
            tilemap.SetTile(new Vector3Int(-1, -37, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -30, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -31, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -32, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -33, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -34, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -35, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -36, 0), null);
            tilemap.SetTile(new Vector3Int(-2, -37, 0), null);
        }
    }

}
