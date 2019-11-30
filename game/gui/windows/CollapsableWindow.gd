extends "res://game/gui/windows/DraggableWindow.gd"

onready var AnimationPlayer = $AnimationPlayer
onready var Button = $VBoxContainer/TitleBar/HBoxContainer/Right/HBoxContainer/Button
onready var initial_height = rect_size.y

export var HEIGHT = 0.0 setget set_height

func _on_Button_toggled(button_pressed):
	if button_pressed:
		AnimationPlayer.play("Expand")
	else:
		AnimationPlayer.play("Collapse")

func _on_TitleBar_mouse_entered():
	is_mouse_inside_titlebar = true

func _on_TitleBar_mouse_exited():
	is_mouse_inside_titlebar = false

func _input(event):
	if is_mouse_inside_titlebar and event is InputEventMouseButton and event.is_action_pressed("ui_left_click") and event.doubleclick:
		Button.pressed = !Button.pressed
		Button.emit_signal("toggled", Button.pressed)

func set_height(value):
	HEIGHT = value
	rect_min_size.y = initial_height * value
	rect_size.y = rect_min_size.y

func _on_ScrollableWindow_focus_entered():
	pass # Replace with function body.
