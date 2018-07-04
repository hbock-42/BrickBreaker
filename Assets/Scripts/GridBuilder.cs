using UnityEngine;

public static class GridBuilder
{
	#region Constants

	///// <summary>
	///// Number of columns
	///// </summary>
	//public const int GridWidth = 10;
	///// <summary>
	///// Number of rows
	///// </summary>
	//public const int GridHeight = 40;

	#endregion

	#region Properties

	/// <summary>
	/// Dimensions of a single cell
	/// We use it to create the bricks
	/// </summary>
	public static Vector3 CellDimensions { get; private set; }

	/// <summary>
	/// Number of columns
	/// </summary>
	public static int GridWidth { get; set; }
	/// <summary>
	/// Number of rows
	/// </summary>
	public static int GridHeight { get; set; }

	#endregion

	#region Constructor

	static GridBuilder()
	{
		Debug.Log("GridBuilder.cs constructor called");
		//CalculateCellDimensions();
	}

	#endregion

	#region Methods

	public static void CalculateCellDimensions()
	{
		Debug.Log("WorldBounds.WorldWidth=" + WorldBounds.WorldWidth);
		Debug.Log("GridWidth=" + GridWidth);
		Debug.Log("WorldBounds.WorldHeight=" + WorldBounds.WorldHeight);
		Debug.Log("GridHeight=" + GridHeight);
		var cellDimensions = new Vector3
		{
			
			x = WorldBounds.WorldWidth / GridWidth,
			y = WorldBounds.WorldHeight / GridHeight,
			z = BrickBuilder.BrickDepth
		};

		CellDimensions = cellDimensions;
	}

	#endregion

}