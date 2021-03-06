﻿using UnityEngine;

public static partial class BrickBuilder
{
	private static readonly int[] VerticesId = new[]
	{
		0, // A
		1, // B
		3, // C
		2, // D
		4, // E
		5, // F
		11, // G
		10 // H
	};

	// ReSharper disable once UnusedMember.Local
	private static void PrintCornersPositions()
	{
		Debug.Log("Vertex positions");
		foreach (var vertexId in VerticesId)
		{
			Debug.Log(Vertices[vertexId]);
		}
	}
}
