using Godot;
using System;
using System.Collections.Generic;

namespace EvolveMono.Game.Resources
{
    public class Resource : Sprite
    {
        public new string Name;

        private static List<Resource> _resources;

        public static List<Resource> All
        {
            get
            {
                if (_resources == null)
                {
                    _resources = new List<Resource>();
                    Type type = typeof(Resource);
                    foreach (var fieldInfo in type.GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
                    {
                        _resources.Add(fieldInfo.GetValue(null) as Resource);
                    }
                }
                return _resources;
            }
        }

        public Resource(string name, string textureName)
        {
            Name = name;
            Texture = ResourceLoader.Load("res://assets/" + textureName) as Texture;
        }

        public static readonly Resource Wood = new Resource("Wood", "Wood.png");
        public static readonly Resource Food = new Resource("Food", "bread.png");

    }
}