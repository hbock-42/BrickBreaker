using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class Grid
{
	#region Constants

	public const int GridWidth = 25;
	public const int GridHeight = 100;

	#endregion

	#region Properties

	public static Vector3 BrickSize { get; private set; }

	#endregion

	#region Constructor

	static Grid()
	{
		CalculateBrickSize();
	}

	#endregion

	#region Methods

	private static void CalculateBrickSize()
	{
		var camera = Camera.main;

		var brickSize = new Vector3
		{
			x = WorldBounds.WorldWidth / (float) GridWidth,
			y = WorldBounds.WorldHeight / (float) GridHeight,
			z = BrickBuilder.BrickDepth
		};

		BrickSize = brickSize;
	}

	#endregion

}