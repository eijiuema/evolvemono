using Godot;
using System;
using System.Collections.Generic;
using EvolveMono.Game.Buildings;
using EvolveMono.Game.Resources;
using Resource = EvolveMono.Game.Resources.Resource;

namespace EvolveMono.Game.Tiles
{
    public class Tile : Godot.Object
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

        public Resource[] Resources
        {
            get => _terrain.Resources;
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
        public static readonly Terrain Plains = new Terrain(0, "Plains", new Resource[] { }, "grass_01.png");
        public static readonly Terrain Forest = new Terrain(1, "Forest", new Resource[] { Resource.Food, Resource.Wood }, "forest_01.png");

        public int Index;
        public string Name;
        public Resource[] Resources;
        public Texture Texture;

        private static List<Terrain> _terrains;
        public static List<Terrain> All
        {
            get
            {
                if (_terrains == null)
                {
                    _terrains = new List<Terrain>();
                    Type type = typeof(Terrain);
                    foreach (var fieldInfo in type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
                    {
                        _terrains.Add(fieldInfo.GetValue(null) as Terrain);
                    }
                }
                return _terrains;
            }
        }

        private Terrain(int index, string name, Resource[] resources, string textureName)
        {
            this.Index = index;
            this.Name = name;
            this.Resources = resources;
            this.Texture = ResourceLoader.Load("res://assets/" + textureName) as Texture;
        }

        public static Terrain GetTerrain(int index)
        {
            foreach (var terrain in All)
            {
                if (terrain.Index == index)
                {
                    return terrain;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}