using Godot;
using System.Linq;
using EvolveMono.Game;
using EvolveMono.Game.Tiles;
using Resource = EvolveMono.Game.Resources.Resource;

namespace EvolveMono.Game.Gui.TileInfo
{

    public class TileInfo : PanelContainer
    {

        private TerrainInfo TerrainInfo;
        private Node ResourceInfoContainer;

        private PackedScene ResourceInfoScene = (PackedScene)ResourceLoader.Load("res://game/gui/tileinfo/ResourceInfo.tscn");

        private Map Map;

        public override void _Ready()
        {
            Map = GetNode<Map>("/root/Game/Map");
            Map.Connect("TileHovered", this, "_on_TileHovered");

            TerrainInfo = GetNode<TerrainInfo>("MarginContainer/VBoxContainer/TerrainInfo");
            ResourceInfoContainer = GetNode("MarginContainer/VBoxContainer/ResourceInfoContainer");

            foreach (var resource in Resource.All)
            {
                ResourceInfo resourceInfo = ResourceInfoScene.Instance() as ResourceInfo;
                resourceInfo.Resource = resource;
                ResourceInfoContainer.AddChild(resourceInfo);
            }
        }

        private void _on_TileHovered(Tile tile)
        {
            TerrainInfo.Terrain = tile.Terrain;
            foreach (ResourceInfo resourceInfo in ResourceInfoContainer.GetChildren())
            {
                if (tile.Terrain.Resources.Contains(resourceInfo.Resource))
                {
                    resourceInfo.Show();
                }
                else
                {
                    resourceInfo.Hide();
                }
            }
        }
    }

}