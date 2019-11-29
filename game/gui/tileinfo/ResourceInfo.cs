using Godot;
using EvolveMono.Game.Tiles;
using Resource = EvolveMono.Game.Resources.Resource;

namespace EvolveMono.Game.Gui.TileInfo
{

    public class ResourceInfo : HBoxContainer
    {
        private TextureRect TextureRect;
        private Label Label;

        public Resource Resource;

        public override void _Ready()
        {
            TextureRect = GetNode<TextureRect>("TextureRect");
            Label = GetNode<Label>("Label");
            TextureRect.Texture = Resource.Texture;
            Label.Text = Resource.Name;
        }
    }

}