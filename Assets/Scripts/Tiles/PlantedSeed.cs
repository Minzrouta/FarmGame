using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class PlantedSeed
{
    public TileBase seedTile;
    public FieldScript field;

    public PlantedSeed(TileBase seedTile, FieldScript field)
    {
        this.seedTile = seedTile;
        this.field = field;
    }
}