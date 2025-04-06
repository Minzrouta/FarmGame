using UnityEngine;
using UnityEngine.Tilemaps;

public class Seed : MonoBehaviour
{
    new public string name;
    public TileBase tile;
    public float growthTime;
    public int price;
    public int sellPrice;

    public Seed(string name, TileBase tile, float growthTime)
    {
        this.name = name;
        this.tile = tile;
        this.growthTime = growthTime;
    }
}