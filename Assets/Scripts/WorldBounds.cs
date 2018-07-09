using UnityEngine;

public static class WorldBounds
{
	#region Enums

	public enum Side
	{
		Left,
		Top,
		Right,
		Bot,
		None
	}

	#endregion

	#region Fields

	private static readonly Vector3 UpLeftBound;
	private static readonly Vector3 BotRightBound;

	#endregion

	#region Properties

	public static float WorldWidth
	{
		get { return Mathf.Abs(BotRightBound.x - UpLeftBound.x); }
	}

	public static float WorldHeight
	{
		get { return Mathf.Abs(BotRightBound.y - UpLeftBound.y); }
	}

	public static Vector3 WorldCenter
	{
		get { return new Vector3(0.5f * (BotRightBound.x + UpLeftBound.x), 0.5f * (BotRightBound.y + UpLeftBound.y), 0); }
	}

	public static Vector3 CameraPositionZeroedZ
	{
		get { return new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0); }
	}

	public static Side HitSide { get; set; }

	public static Vector3 ContactNormal
	{
		get
		{
			switch (HitSide)
			{
				case Side.Left:
					return Vector3.right;
				case Side.Right:
					return Vector3.left;
				case Side.Top:
					return Vector3.down;
				case Side.Bot:
					return Vector3.up;
				default:
					return Vector3.down;
			}
		}
	}

	#endregion

	#region Constructor

	static WorldBounds()
	{
		Debug.Log("WorldBounds.cs constructor called");
		var camera = Camera.main;
		UpLeftBound = camera.ScreenToWorldPoint(new Vector3(0, camera.scaledPixelHeight, 0));
		BotRightBound = camera.ScreenToWorldPoint(new Vector3(camera.scaledPixelWidth, 0, 0));

		Debug.Log("up left world: " + UpLeftBound);
		Debug.Log("down right world: " + BotRightBound);
	}

	#endregion

	#region Methods

	/// <summary>
	/// Is a point inside world bounds
	/// Only x and y coordinates are taken in account
	/// </summary>
	/// <param name="point"></param>
	/// <returns></returns>
	public static bool IsIn(Vector3 point)
	{
		if (point.x < UpLeftBound.x || point.x > BotRightBound.x || point.y > UpLeftBound.y || point.y < BotRightBound.y) return false;
		return true;
	}

	/// <summary>
	/// Check if a sphere is touching world bounds
	/// </summary>
	/// <param name="point"></param>
	/// <param name="radius"></param>
	/// <returns></returns>
	public static bool IsSphereTouching(Vector3 point, float radius)
	{
		HitSide = Side.None;
		var value = point.x - radius;
		if (value < UpLeftBound.x) HitSide = Side.Left;
		value = point.x + radius;
		if (value > BotRightBound.x) HitSide = Side.Right;
		value = point.y + radius;
		if (value > UpLeftBound.y) HitSide = Side.Top;
		value = point.y - radius;
		if (value < BotRightBound.y) HitSide = Side.Bot;
		return HitSide != Side.None;
	}

	#endregion


}