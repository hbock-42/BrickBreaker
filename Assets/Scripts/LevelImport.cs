using System;
using System.Linq;
using System.Xml.Linq;
using Data;

/// <summary>
/// Load an Xml file containg level data
/// and parse it to create a Level instance
/// </summary>
public static class LevelImport
{
	public static Level FromXml(string path)
	{
		var xDoc = XDocument.Load(path);
		return ParseXml(xDoc);
	}

	private static Level ParseXml(XDocument xDoc)
	{
		var levelElem = xDoc.Element("Level");
		if (levelElem == null || levelElem.Attribute("Width") == null || levelElem.Attribute("Height") == null) return null;

		// ReSharper disable once PossibleNullReferenceException
		var width = int.Parse(levelElem.Attribute("Width").Value);
		// ReSharper disable once PossibleNullReferenceException
		var height = int.Parse(levelElem.Attribute("Height").Value);

		int[,] levelArray;
		if (!TryParseLevelArray(levelElem.Value, width, height, out levelArray)) return null;
		return new Level(levelArray);
	}

	/// <summary>
	/// Try to parse a string into a 2 dimensions int array
	/// </summary>
	/// <param name="levelString"></param>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <param name="levelArray"></param>
	/// <returns></returns>
	private static bool TryParseLevelArray(string levelString, int width, int height, out int[,] levelArray)
	{
		levelArray = new int[width, height];
		var levelLines = levelString.Split('\n');
		var levelStringArray = new string[height][];

		for (var h = 0; h < height; h++)
		{
			levelStringArray[h] = levelLines[h].Split(',');
			if (levelStringArray[h].Length != width) return false;
		}

		for (var h = 0; h < height; h++)
		{
			for (var w = 0; w < width; w++)
			{
				levelArray[h, w] = int.Parse(levelStringArray[h][w]);
			}
		}

		return true;
	}
}