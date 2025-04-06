using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class FieldScript : MonoBehaviour
{
    public bool isPlanted = false;
    private bool isGrowing = false;
    private Tilemap plantsTilemap;
    private Tilemap terrainTilemap;
    private float timer = 0f;
    private Transform _ui;
    
    private Seed plantedSeed;
    
    private VisualElement progressBar;
    private VisualElement root;

    void Start()
    {
        plantsTilemap = GameObject.Find("Plants Tilemap").GetComponent<Tilemap>();
        terrainTilemap = GameObject.Find("Terrain Tilemap").GetComponent<Tilemap>();

        _ui = transform.Find("ui");
        var uiDoc = _ui.GetComponent<UIDocument>();
        root = uiDoc.rootVisualElement;
        progressBar = root.Q<VisualElement>("progressBar");
        
        if (progressBar == null)
        {
            Debug.LogError("Progress bar not found!");
        }
        
        root.style.visibility = Visibility.Hidden; // Hide the UI at the start

        if (plantsTilemap == null || terrainTilemap == null)
        {
            Debug.LogError("Tilemaps not found!");
        }
    }
    
    void Update()
    {
        if (isGrowing)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / plantedSeed.growthTime);
            progressBar.style.width = Length.Percent(progress * 100f);

            if (progress >= 1f)
            {
                isGrowing = false;
                root.style.visibility = Visibility.Hidden; // Hide the UI when growth is complete
                progressBar.style.width = Length.Percent(0f); // Reset progress bar
                Debug.Log("Plante mature !");
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Field clicked: " + this.gameObject.name);
        if (!isPlanted && GameManager.Instance.selectedSeed != null)
        {
            PlantSeed();
        }
        else
        {
            HarvestCrop();
        }
    }

    private void PlantSeed()
    {
        if (GameManager.Instance.selectedSeed.tile != null && plantsTilemap != null)
        {
            if (GameManager.Instance.inventory.ContainsKey(GameManager.Instance.selectedSeed.name) &&
                GameManager.Instance.inventory[GameManager.Instance.selectedSeed.name] > 0)
            {
                Vector3 worldPosition = transform.position;
                Vector3Int cellPosition = plantsTilemap.WorldToCell(worldPosition);

                plantsTilemap.SetTile(cellPosition, GameManager.Instance.selectedSeed.tile);
                isGrowing = true;
                timer = 0f;
                root.style.visibility = Visibility.Visible; // Show the UI when planting

                plantedSeed = GameManager.Instance.selectedSeed; //Peut etre a changer en faisant une copie
                isPlanted = true;
                Debug.Log(this.gameObject.name + " was clicked and seed planted");
                GameManager.Instance.RemoveFromInventory(GameManager.Instance.selectedSeed.name, 1); // Remove one seed from inventory
            }
            else
            {
                Debug.Log("Not enough seeds");
            }
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
            if (isGrowing)
            {
                Debug.Log("Crop is not ready to be harvested.");
                return;
            }
            Vector3 worldPosition = transform.position;
            Vector3Int cellPosition = plantsTilemap.WorldToCell(worldPosition);
            plantsTilemap.SetTile(cellPosition, null);
            isPlanted = false;
            Debug.Log(this.gameObject.name + " was clicked and crop harvested");
            GameManager.Instance.AddMoney(plantedSeed.sellPrice); 
        }
        else
        {
            Debug.LogError("Plants tilemap is not assigned.");
        }
    }
}