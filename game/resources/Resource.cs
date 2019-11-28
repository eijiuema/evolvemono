using Godot;

namespace EvolveMono.Game.Resources
{
    public class Resource : Sprite
    {
        [Export]
        public ResourceType ResourceType;
    }
    
    public enum ResourceType
    {
        Wood,
        Food
    }
}