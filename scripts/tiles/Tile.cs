using Godot;
using EvolveMono.Scripts.Buildings;
using EvolveMono.Scripts.Resources;

namespace EvolveMono.Scripts.Tiles
{
    public class Tile
    {
        private Terrain _terrain;
        public Terrain Terrain
        {
            get => _terrain;
            // set => _terrain = value;
        }

        public Tile()
        {
            GD.Print(Resources.ResourceType.Food);
        }

        private Godot.Collections.Array<Building> _buildings = new Godot.Collections.Array<Building>();
        public Godot.Collections.Array<Building> Buildings
        {
            get => _buildings;
        }

        private Vector2 _coordinates;
        public Vector2 Coordinates
        {
            get => _coordinates;
            set => _coordinates = value;
        }

        public Tile(Terrain terrain, Vector2 coordinates)
        {
            _terrain = terrain;
            _coordinates = coordinates;
        }

        public void AddBuilding(Building building)
        {
            _buildings.Add(building);
        }

        public void RemoveBuilding(Building building)
        {
            _buildings.Remove(building);
        }
    }

    public enum Terrain
    {
        Wood,
        Forest
    }
}