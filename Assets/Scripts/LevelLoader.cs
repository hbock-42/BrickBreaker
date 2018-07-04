using System.IO;
using System.Xml.Linq;

public static class LevelLoader
{
	public static void FromXml(string path)
	{
		var xDoc = XDocument.Load(Path.Combine(SetupStrings.LevelSavePath, "LevelTest.xml"));

	}
}