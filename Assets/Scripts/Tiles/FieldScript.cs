using UnityEngine;
using UnityEngine.Tilemaps;

public class FieldScript : MonoBehaviour
{
    public bool isPlanted = false;
    public TileBase seedTile;

    private Tilemap plantsTilemap;
    private Tilemap terrainTilemap;
    private PlantedSeed plantedSeed;

    void Start()
    {
        plantsTilemap = GameObject.Find("Plants Tilemap").GetComponent<Tilemap>();
        terrainTilemap = GameObject.Find("Terrain Tilemap").GetComponent<Tilemap>();

        if (plantsTilemap == null || terrainTilemap == null)
        {
            Debug.LogError("Tilemaps not found!");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Field clicked: " + this.gameObject.name);
        if (!isPlanted)
        {
            PlantSeed();
            isPlanted = true;
            Debug.Log(this.gameObject.name + " was clicked and seed planted");
        }
        else
        {
            HarvestCrop();
        }
    }

    private void PlantSeed()
    {
        if (seedTile != null && plantsTilemap != null)
        {
            Vector3 worldPosition = transform.position;
            Vector3Int cellPosition = plantsTilemap.WorldToCell(worldPosition);

            plantsTilemap.SetTile(cellPosition, seedTile);
            plantedSeed = new PlantedSeed(seedTile, this); // Store the planted seed
        }
        else
        {
            Debug.LogError("Seed tile or plants tilemap is not assigned.");
        }
    }

    private void HarvestCrop()
    {
        if (plantsTilemap != null)
        {
            Vector3 worldPosition = transform.position;
            Vector3Int cellPosition = plantsTilemap.WorldToCell(worldPosition);
            plantsTilemap.SetTile(cellPosition, null); // Remove the crop
            isPlanted = false; // Reset the planted state
            plantedSeed = null; // Reset the planted seed
            Debug.Log(this.gameObject.name + " was clicked and crop harvested");
        }
        else
        {
            Debug.LogError("Plants tilemap is not assigned.");
        }
    }
}