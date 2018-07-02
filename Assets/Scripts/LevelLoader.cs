using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

public static class LevelLoader
{
	public static void FromXml(string path)
	{
		var xDoc = XDocument.Load(Path.Combine(SetupStrings.LevelSavePath, "LevelTest.xml"));

	}

	// Make a common repo to not duplicate class
}