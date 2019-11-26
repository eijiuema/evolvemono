using EvolveMono.Scripts.Tiles;
using Godot;
using Godot.Collections;

public static class TileManager
{
    private static Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();
    public static Dictionary<Vector2, Tile> Tiles
    {
        get => _tiles;
    }

    public static void PutTile(Vector2 coordinates, Tile tile)
    {
        _tiles.Add(coordinates, tile);
    }

    public static void RemoveTile(Vector2 coordinates)
    {
        _tiles.Remove(coordinates);
    }
}