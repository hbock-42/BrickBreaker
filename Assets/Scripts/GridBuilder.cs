using UnityEngine;

public static class GridBuilder
{
	#region Constants

	/// <summary>
	/// Number of columns
	/// </summary>
	public const int GridWidth = 10;
	/// <summary>
	/// Number of rows
	/// </summary>
	public const int GridHeight = 40;

	#endregion

	#region Properties

	/// <summary>
	/// Dimensions of a single cell
	/// We use it to create the bricks
	/// </summary>
	public static Vector3 CellDimensions { get; private set; }

	#endregion

	#region Constructor

	static GridBuilder()
	{
		CalculateCellDimensions();
	}

	#endregion

	#region Methods

	private static void CalculateCellDimensions()
	{
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