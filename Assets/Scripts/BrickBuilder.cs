using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// Dirty
// TODO: Make this works with variable vertices number (SuperVolume repository)
public static class BrickBuilder
{
	#region Constants

	public const float BrickDepth = 1f;

	#endregion

	#region Fields

	private static readonly Vector3[] Vertices;

	#endregion

	#region Properties

	private static Vector3 V1 { get { return Vertices[0]; } }
	private static Vector3 V2 { get { return Vertices[1]; } }
	private static Vector3 V3 { get { return Vertices[2]; } }
	private static Vector3 V4 { get { return Vertices[3]; } }
	private static Vector3 V5 { get { return Vertices[4]; } }
	private static Vector3 V6 { get { return Vertices[5]; } }
	private static Vector3 V7 { get { return Vertices[6]; } }
	private static Vector3 V8 { get { return Vertices[7]; } }

	#endregion

	#region Constructor

	static BrickBuilder()
	{
		Vertices = new Vector3[8];
		CalculateVextices();
	}

	#endregion

	#region Methods

	private static void CalculateVextices()
	{
		var w = Grid.BrickSize.x / 2f;
		var h = Grid.BrickSize.y / 2f;
		var d = Grid.BrickSize.z / 2f;

		Vertices[0] = new Vector3(-w, +h, -d);
		Vertices[1] = new Vector3(+w, +h, -d);
		Vertices[2] = new Vector3(-w, -h, -d);
		Vertices[3] = new Vector3(+w, -h, -d);
		Vertices[4] = new Vector3(-w, +h, +d);
		Vertices[5] = new Vector3(+w, +h, +d);
		Vertices[6] = new Vector3(-w, -h, +d);
		Vertices[7] = new Vector3(+w, -h, +d);
	}

	// Horrible - I just want to see a result for the moment
	private static void BuildMesh()
	{
		var indices = new int[3 * 12];

		indices[0] = 0;
		indices[1] = 1;
		indices[2] = 3;

		indices[3] = 3;
		indices[4] = 2;
		indices[5] = 4;

		indices[6] = 4;
		indices[7] = 7;
		indices[8] = 3;

		indices[9] = 3;
		indices[10] = 3;
		indices[11] = 3;

	}

	#endregion
}