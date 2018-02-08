using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class GenerateTumour2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var input_file = Path.Combine(Directory.GetCurrentDirectory(), "out.csv");
		var reader = new StreamReader(input_file);

		// Skip lines not pertaining to fields
		reader.ReadLine();

		while (!reader.EndOfStream) {

			// Start reading at line 2
			var line = reader.ReadLine();
			var fields = line.Split(',');

			// For each remaining line in the input file, generate a sphere
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

			// Colour the sphere based on the values provided by the input file
			Color colour = Color.red;
			if (double.Parse(fields [2]) == 1.0) {
				colour = Color.green;
			}
			sphere.GetComponent<MeshRenderer> ().material.SetColor ("_Color", colour);
            
			// Place the sphere based on the values provided by the input file
            sphere.transform.position = new Vector3(float.Parse(fields [6]), float.Parse(fields [7]), float.Parse(fields [8]));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
