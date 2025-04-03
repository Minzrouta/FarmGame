using UnityEngine;
using UnityEngine.Tilemaps;

public class FieldScript : MonoBehaviour
{
    public bool isPlanted = false;
    public GameObject seedPrefab; //change this later to the selected seed

    private Tilemap plantsTilemap;
    private Tilemap terrainTilemap;

    void Start()
    {
        // Recherche des tilemaps dans la scène
        plantsTilemap = GameObject.Find("Plants Tilemap").GetComponent<Tilemap>();
        terrainTilemap = GameObject.Find("Terrain Tilemap").GetComponent<Tilemap>();

        if (plantsTilemap == null || terrainTilemap == null)
        {
            Debug.LogError("Tilemaps not found!");
        }
    }


    private void OnMouseDown()
    {
        if (!isPlanted)
        {
            plantSeed();
            isPlanted = true;
            Debug.Log(this.gameObject.name + " was clicked and seed planted");
        }
        else
        {
            //HarvestCrop();
        }
    }

    private void plantSeed()
    {
        if (seedPrefab != null && plantsTilemap != null)
        {
            Vector3 worldPosition = transform.position;
            Vector3Int cellPosition = plantsTilemap.WorldToCell(worldPosition);
            Vector3 cellCenterPosition = plantsTilemap.GetCellCenterWorld(cellPosition);
            Instantiate(seedPrefab, cellCenterPosition, Quaternion.identity, plantsTilemap.transform);
        }
        else
        {
            Debug.LogError("Seed prefab or plants tilemap is not assigned.");
        }
    }
}