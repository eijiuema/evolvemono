extends MarginContainer

var is_mouse_inside_titlebar = false
var is_draggable = false

func _on_TitleBar_mouse_entered():
	is_mouse_inside_titlebar = true

func _on_TitleBar_mouse_exited():
	is_mouse_inside_titlebar = false

func _input(event):
	if is_mouse_inside_titlebar and event.is_action_pressed("ui_left_click"):
		is_draggable = true
		Input.set_mouse_mode(Input.MOUSE_MODE_CONFINED);
	elif is_draggable and event.is_action_released("ui_left_click"):
		is_draggable = false
		Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE);

	if is_draggable and event is InputEventMouseMotion:
		set_position(get_position() + event.get_relative())