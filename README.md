# godot-onnx-demo

- Godot 4.2 dev4 mono (Needs to support Android export with C# to use ML.NET for onnx)
- Python 3+ with Pytorch compatible with onnx export (2.1 used)


Interference on PC works as intended.

Interference on Android devices fails. On net7.0 there is missing onnxruntime DLL on Android. Godot seems to not support net6.0 for android export.


```
USER ERROR: System.TypeInitializationException: The type initializer for 'Microsoft.ML.OnnxRuntime.NativeMethods' threw an exception.
 ---> System.DllNotFoundException: onnxruntime
   at Microsoft.ML.OnnxRuntime.NativeMethods..cctor()
   --- End of inner exception stack trace ---
   at Microsoft.ML.OnnxRuntime.SessionOptions..ctor()
   at Microsoft.ML.OnnxRuntime.InferenceSession..ctor(Byte[] model)
   at Label._Ready()
   at Godot.Node.InvokeGodotClassMethod(godot_string_name& method, NativeVariantPtrArgs args, godot_variant& ret)
   at Godot.CanvasItem.InvokeGodotClassMethod(godot_string_name& method, NativeVariantPtrArgs args, godot_variant& ret)
   at Godot.Control.InvokeGodotClassMethod(godot_string_name& method, NativeVariantPtrArgs args, godot_variant& ret)
   at Godot.Label.InvokeGodotClassMethod(godot_string_name& method, NativeVariantPtrArgs args, godot_variant& ret)
   at Label.InvokeGodotClassMethod(godot_string_name& method, NativeVariantPtrArgs args, godot_variant& ret)
   at Godot.Bridge.CShar
   at: void Godot.NativeInterop.ExceptionUtils.LogException(System.Exception) (:0)
```
