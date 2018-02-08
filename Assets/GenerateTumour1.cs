 // credit to http://wiki.unity3d.com/index.php?title=HexConverter

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class GenerateTumour1 : MonoBehaviour {

	Color HexToColor(string hex) {
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}

	// Use this for initialization
	void Start () {
		var input_file = Path.Combine(Directory.GetCurrentDirectory(), "pointcloud_10000.pcd");
		var reader = new StreamReader(input_file);

		// Skip lines not pertaining to x y z rgb fields
		for (var i = 0; i < 11; i++) reader.ReadLine();

		while (!reader.EndOfStream) {

			// Start reading at line 12
			var line = reader.ReadLine();
			var fields = line.Split(' ');

			// For each remaining line in the input file, generate a sphere
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

			// Colour the sphere based on the values provided by the input file
			Color colour = HexToColor (fields [3]);
            sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", colour);

            // Place the sphere based on the values provided by the input file
            sphere.transform.position = new Vector3(float.Parse(fields [0]), float.Parse(fields [1]), float.Parse(fields [2]));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
