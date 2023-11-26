# godot-onnx-demo

- Godot 4.2 dev4 mono
- Python 3+ with Pytorch compatible with onnx export (2.1 used)


Interference on PC works as intended.

Interference on Android devices fails. On net7.0 there is missing onnxruntime DLL on Android. Godot seems to not support net6.0 for android export.
