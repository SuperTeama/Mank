using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Profile {
	//private static Profile profile;
	public static Profile Inst = new Profile();
	private Dictionary<string, string> mapStringValues = new Dictionary<string, string>();
	private Dictionary<string, int> mapIntValues = new Dictionary<string, int>();
	private Dictionary<string, float> mapFloatValues = new Dictionary<string, float>();
	private Dictionary<string, bool> mapBoolValues = new Dictionary<string, bool>();

	private string profileName;

	private Profile()
	{
		profileName = "Assets/Properties/profile.xml";
		LoadProfile ();
	}

	public void LoadProfile()
	{
		XmlTextReader reader = new XmlTextReader(profileName);
		while (reader.Read()) {
			if (reader.Name == "String") {
				mapStringValues.Add(reader.GetAttribute("id"), reader.ReadString());
				continue;
			}
			if (reader.Name == "Int") {
				mapIntValues.Add(reader.GetAttribute("id"), int.Parse(reader.ReadString()));
				continue;
			}
			if (reader.Name == "Float") {
				mapFloatValues.Add(reader.GetAttribute("id"), float.Parse(reader.ReadString()));
				continue;
			}
			if (reader.Name == "Bool") {
				mapBoolValues.Add(reader.GetAttribute("id"), bool.Parse(reader.ReadString()));
				continue;
			}
		}
		reader.Close();
	}

	public void SaveProfile()
	{
		XmlDocument xmlDoc = new XmlDocument();
		XmlNode rootNode = xmlDoc.CreateElement("Profile");
		xmlDoc.AppendChild(rootNode);
		
		XmlNode userNode;

		foreach (KeyValuePair<string, string> pair in mapStringValues) {
			userNode = xmlDoc.CreateElement("String");
			XmlAttribute attribute; 
			attribute = xmlDoc.CreateAttribute("id");
			attribute.Value = pair.Key;
			userNode.Attributes.Append(attribute);
			userNode.InnerText = pair.Value;
			rootNode.AppendChild(userNode);
		}
		foreach (KeyValuePair<string, int> pair in mapIntValues) {
			userNode = xmlDoc.CreateElement("Int");
			XmlAttribute attribute; 
			attribute = xmlDoc.CreateAttribute("id");
			attribute.Value = pair.Key;
			userNode.Attributes.Append(attribute);
			userNode.InnerText = pair.Value.ToString();
			rootNode.AppendChild(userNode);
		}
		foreach (KeyValuePair<string, float> pair in mapFloatValues) {
			userNode = xmlDoc.CreateElement("Float");
			XmlAttribute attribute; 
			attribute = xmlDoc.CreateAttribute("id");
			attribute.Value = pair.Key;
			userNode.Attributes.Append(attribute);
			userNode.InnerText = pair.Value.ToString();
			rootNode.AppendChild(userNode);
		}
		foreach (KeyValuePair<string, bool> pair in mapBoolValues) {
			userNode = xmlDoc.CreateElement("Bool");
			XmlAttribute attribute; 
			attribute = xmlDoc.CreateAttribute("id");
			attribute.Value = pair.Key;
			userNode.Attributes.Append(attribute);
			userNode.InnerText = pair.Value.ToString();
			rootNode.AppendChild(userNode);
		}
		
		xmlDoc.Save(profileName);
	}
	
	public void SetStringValue(string pKey, string pValue)
	{
		if (!mapStringValues.ContainsKey (pKey)) {
			mapStringValues.Add (pKey, pValue);
		} else {
			mapStringValues[pKey] = pValue;
		}
	}

	public string GetStringValue(string pKey)
	{
		string temp = null;

		if(mapStringValues.TryGetValue(pKey, out temp)) {
			return temp;
		} else {
			return "";
		}
	}

	public void SetIntValue(string pKey, int pValue)
	{
		if (!mapIntValues.ContainsKey (pKey)) {
			mapIntValues.Add (pKey, pValue);
		} else {
			mapIntValues[pKey] = pValue;
		}
	}
	
	public int GetIntValue(string pKey)
	{
		int temp = 0;
		
		if(mapIntValues.TryGetValue(pKey, out temp)) {
			return temp;
		} else {
			return 0;
		}
	}

	public void SetFloatValue(string pKey, float pValue)
	{
		if (!mapFloatValues.ContainsKey (pKey)) {
			mapFloatValues.Add (pKey, pValue);
		} else {
			mapFloatValues[pKey] = pValue;
		}
	}
	
	public float GetFloatValue(string pKey)
	{
		float temp = 0.0f;
		
		if(mapFloatValues.TryGetValue(pKey, out temp)) {
			return temp;
		} else {
			return 0.0f;
		}
	}

	public void SetBoolValue(string pKey, bool pValue)
	{
		if (!mapBoolValues.ContainsKey (pKey)) {
			mapBoolValues.Add (pKey, pValue);
		} else {
			mapBoolValues[pKey] = pValue;
		}
	}
	
	public bool GetBoolValue(string pKey)
	{
		bool temp = false;
		
		if(mapBoolValues.TryGetValue(pKey, out temp)) {
			return temp;
		} else {
			return false;
		}
	}

}
