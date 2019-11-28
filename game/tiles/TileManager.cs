using Godot;
using System.Collections.Generic;
using EvolveMono.Game.Tiles;

public static class TileManager
{

    public static TilesDictionary Tiles = new TilesDictionary();

    public class TilesDictionary
    {
        private Dictionary<Vector2, Tile> _tiles = new Dictionary<Vector2, Tile>();
        public Tile this[Vector2 pos]
        {
            get => _tiles.ContainsKey(pos) ? _tiles[pos] : null;
            set => _tiles[pos] = value;
        }
        public Tile this[int x, int y]
        {
            get => this[new Vector2(x, y)];
            set => this[new Vector2(x, y)] = value;
        }
        public Tile this[float x, float y]
        {
            get => this[(int)x, (int)y];
            set => this[(int)x, (int)y] = value;
        }
    }
}