extends Camera2D

export(float) var ZOOM_STEP
export(float) var ZOOM_MAX
export(float) var ZOOM_MIN

var mouse_captured = false

var follow = null

func _input(event):
	if mouse_captured and event is InputEventMouseMotion:
		offset -= event.get_relative() * zoom
		follow = null

func _process(delta):
	if follow != null:
		if is_instance_valid(follow):
			offset = follow.position;
		else:
			follow = null

func _unhandled_input(event):
	
	if event.is_action_pressed("map_left_click"):
		mouse_captured = true
		Input.set_mouse_mode(Input.MOUSE_MODE_CONFINED)
	elif event.is_action_released("map_left_click"):
		mouse_captured = false
		Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE)
		
	if event.is_action_pressed("map_zoom_out"):
		zoom *= ZOOM_STEP
	elif event.is_action_pressed("map_zoom_in"):
		zoom /= ZOOM_STEP
		
	if zoom.x > ZOOM_MAX:
		zoom = Vector2(1, 1) * ZOOM_MAX
	elif zoom.x < ZOOM_MIN:
		zoom = Vector2(1, 1) * ZOOM_MIN