using Godot;

namespace EvolveMono.Scripts.Resources
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