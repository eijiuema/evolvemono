using Godot;

namespace EvolveMono.Scripts
{

    public class Camera : Camera2D
    {
        [Export]
        private float _zoomStep, _zoomMax, _zoomMin;

        // State of the left click (true => pressed / false => released)
        private bool _mouseCaptured = false;
        public override void _Ready()
        {
            Input.SetMouseMode(Input.MouseMode.Confined);
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            // Handles dragging
            if (@event.IsActionPressed("map_left_click"))
            {
                _mouseCaptured = true;
            }
            else if (@event.IsActionReleased("map_left_click"))
            {
                _mouseCaptured = false;
            }

            if (_mouseCaptured && @event is InputEventMouseMotion eventMouseMotion)
            {
                Offset -= eventMouseMotion.Relative * Zoom;
            }

            // Handles zooming
            if (@event.IsActionPressed("map_zoom_out"))
            {
                Zoom *= _zoomStep;
            }
            else if (@event.IsActionPressed("map_zoom_in"))
            {
                Zoom /= _zoomStep;
            }

            if (Zoom.x > _zoomMax)
            {
                Zoom = new Vector2(1, 1) * _zoomMax;
            }

            if (Zoom.y < _zoomMin)
            {
                Zoom = new Vector2(1, 1) * _zoomMin;
            }
        }

    }

}