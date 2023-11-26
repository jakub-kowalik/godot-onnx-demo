using Godot;
using System;

using Microsoft.ML.OnnxRuntime;
using System.Collections.Generic;
using Microsoft.ML.OnnxRuntime.Tensors;

using System.Linq;


// Define a class for input data

public partial class Label : Godot.Label
{
	static string ONNX_MODEL_PATH = "res://simple_model.onnx";
	InferenceSession session;
	RunOptions runOptions;
	SessionOptions sessionOptions;

	double timer = 0.0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		byte[] model_bytes = FileAccess.GetFileAsBytes("res://simple_model.onnx");

		session = new InferenceSession(model_bytes);
		runOptions = new RunOptions();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		GD.Print("Test");

		timer += delta;

		if (timer < 1.0) 
		{
			return;
		}

		timer = 0.0;
		Random random = new Random();

		int[] shape = { 1, 10 };

		float[] values = GenerateRandomArray(10);

		DenseTensor<float> tensor = new DenseTensor<float>(values, shape);

        // Create an input container
        var inputContainer = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor<float>("input", tensor)
        };

	 	var results = session.Run(inputContainer);

		Text = random.NextDouble().ToString();
		// Text = results[0].AsTensor<float>().GetArrayString();

	}

	private float[] GenerateRandomArray(int length) 
	{
		float[] randomFloats = new float[10];

        // Create a Random object
        Random random = new Random();

        // Fill the array with random floats between 0 and 1
        for (int i = 0; i < randomFloats.Length; i++)
        {
            randomFloats[i] = (float)random.NextDouble();
        }

		return randomFloats;
	}
}
