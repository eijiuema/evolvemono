using Godot;
using EvolveMono.Game.Tiles;

namespace EvolveMono.Game.Gui.TileInfo
{

    public class TerrainInfo : VBoxContainer
    {
        private Terrain _terrain;

        private TextureRect TextureRect;
        private Label Label;

        [Export]
        public Terrain Terrain
        {
            get => _terrain;
            set
            {
                _terrain = value;
                TextureRect.Texture = Terrain.Texture;
                Label.Text = Terrain.Name;
            }
        }

        public override void _Ready()
        {
            TextureRect = GetNode<TextureRect>("TextureRect");
            Label = GetNode<Label>("Label");
        }
    }

}