using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Settings {
	private Dictionary<string, float> mapFloatValues = new Dictionary<string, float>();
	private string settingsName;
	private string paramName;
	
	public Settings(string theParamName)
	{
		settingsName = "Assets/Properties/settings.xml";
		paramName = theParamName;
		LoadSettings ();
	}
	
	public void LoadSettings()
	{
		XmlTextReader reader = new XmlTextReader(settingsName);

		while (reader.Read()) {
			if (reader.Name == paramName) {
				//foreach(XmlTextReader node in reader) {
					//for (int i = 0; i < reader.AttributeCount; i++) {
						//mapFloatValues.Add(paramName + "_" + node.Name, float.Parse(node.Value));
					//}
				//}
				continue;
			} else {
				continue;
			}
		}
		reader.Close();
	}
}