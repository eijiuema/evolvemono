using Godot;
using System.Collections.Generic;

namespace EvolveMono.Game.Units
{

    public class Unit : Sprite
    {	
		[Signal]
        public delegate void PathEnded();

        private float _speed;
        [Export]
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        private int _energy;
        [Export]
        public int Energy
        {
            get => _energy;
            set => _energy = value;
        }

        private List<Vector2> _path;
        public List<Vector2> Path
        {
            set
            {
                _path = value;
                if (value.Count > 0)
                    SetProcess(true);
            }
        }
		
		private List<Resource> _resources;
		public List<Resource> Resources
		{
			get => _resources;
			set => _resources = value;
		}

//        public override void _UnhandledInput(InputEvent @event)
//        {
//            if (@event.IsActionPressed("test_right_click"))
//            {
//                var parent = GetParent() as Map;
//                var line = parent.GetNode("Line2D") as Line2D;
//                var path = parent.GetSimplePath(GlobalPosition, parent.HoveredSprite.Position);
//                line.Points = path;
//                Path = new List<Vector2>(path);
//            }
//        }

        public override void _Ready()
        {
            SetProcess(false);
        }

        public override void _Process(float delta)
        {
            var moveDistance = delta * _speed;
            MoveAlongPath(moveDistance);
        }

        private void MoveAlongPath(float distance)
        {
            var startPoint = Position;
            for (int i = 0; i < _path.Count; i++)
            {
                var distanceToNext = startPoint.DistanceTo(_path[0]);
                if (distance <= distanceToNext && distance >= 0.0f)
                {
                    Position = startPoint.LinearInterpolate(_path[0], distance / distanceToNext);
                    break;
                }
                else if (_path.Count == 1)
                {
                    Position = _path[0];
                    SetProcess(false);
                    EmitSignal("PathEnded");
                    break;
                }
                distance -= distanceToNext;
                startPoint = _path[0];
                _path.RemoveAt(0);
            }
        }

    }

}