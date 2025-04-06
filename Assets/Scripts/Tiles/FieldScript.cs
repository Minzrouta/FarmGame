using UnityEngine;
using UnityEngine.Tilemaps;

public class FieldScript : MonoBehaviour
{
    public bool isPlanted = false;
    public GameObject seedPrefab; // Prefab de la graine à planter
    private Seed selectedSeed;
    private Tilemap plantsTilemap;
    private Tilemap terrainTilemap;

    void Start()
    {
        selectedSeed = seedPrefab.GetComponent<Seed>();
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
        if (!isPlanted && selectedSeed != null)
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
        if (selectedSeed.tile != null && plantsTilemap != null)
        {
            Vector3 worldPosition = transform.position;
            Vector3Int cellPosition = plantsTilemap.WorldToCell(worldPosition);

            plantsTilemap.SetTile(cellPosition, selectedSeed.tile);
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
            Debug.Log(this.gameObject.name + " was clicked and crop harvested");
        }
        else
        {
            Debug.LogError("Plants tilemap is not assigned.");
        }
    }
}