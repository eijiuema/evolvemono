using System;
using System.Collections.Generic;
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

        private List<Building> _buildings = new List<Building>();
        public List<Building> Buildings
        {
            get => _buildings;
        }

        public ResourceType[] Resources
        {
            get => _terrain.ResourceTypes;
        }

        public Tile(Terrain terrain)
        {
            _terrain = terrain;
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

    public class Terrain
    {
        public static readonly Terrain None = new Terrain(-1, "None", new ResourceType[] {});
        public static readonly Terrain Plains = new Terrain(0, "Plains", new ResourceType[] {});
        public static readonly Terrain Forest = new Terrain(1, "Forest", new ResourceType[] {ResourceType.Food, ResourceType.Wood});

        public int Index;
        public string Name;
        public ResourceType[] ResourceTypes;

        private Terrain(int index, string name, ResourceType[] resourceTypes)
        {
            this.Index = index;
            this.Name = name;
            this.ResourceTypes = resourceTypes;
        }

        public static Terrain GetTerrain(int index)
        {
            Type type = typeof(Terrain);
            foreach(var p in type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                var terrain = p.GetValue(null) as Terrain;
                if (terrain.Index == index)
                    return terrain;
            }
            return null;
        }

    }
}