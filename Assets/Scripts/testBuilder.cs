using System.IO;
using Data;
using UnityEngine;

public class testBuilder : MonoBehaviour {


	private void Awake ()
	{
		Debug.Log("testBuilder.cs Awake called");
		var level = LoadLevel();

		// Set grid
		GridBuilder.GridWidth = level.Width;
		GridBuilder.GridHeight = level.Height;
		GridBuilder.CalculateCellDimensions();

		InstantiateBricks(level);

		////Instantiate(BrickBuilder.BrickGo);
		//if (BrickBuilder.BrickGo.activeSelf)
		//{
		//	Debug.Log("Lol");
		//}
	}

	private Level LoadLevel()
	{
		return LevelImport.FromXml(Path.Combine(SetupStrings.LevelSavePath, "LevelTest.xml"));
	}

	private void InstantiateBricks(Level level)
	{
		var horiUnit = GridBuilder.CellDimensions.x;
		var vertiUnit = GridBuilder.CellDimensions.y;
		for (var h = 0; h < level.Height; h++)
		{
			for (var w = 0; w < level.Width; w++)
			{
				if (level.BrickLevelArray[h, w] == 0) continue;
				var brick = Instantiate(BrickBuilder.BrickGo);
				brick.transform.position = new Vector3(horiUnit * w, vertiUnit * h, 0) - new Vector3(WorldBounds.WorldWidth / 2, WorldBounds.WorldHeight / 2, 0);
				brick.SetActive(true);
			}
		}
	}
}
