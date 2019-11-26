using Godot;

namespace EvolveMono.Scripts.Units {

    public class Unit : Sprite {

        private float _speed;
        private int _energy;

        [Export]
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        [Export]
        public int Energy
        {
            get => _energy;
            set => _energy = value;
        }

    }

    public static class UnitType {
        public static PackedScene BaseUnit = ResourceLoader.Load("res://scenes/units/BaseUnit.tscn") as PackedScene;
    }

}