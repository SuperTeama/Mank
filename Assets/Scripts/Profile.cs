using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Profile {
	//private static Profile profile;
	public static Profile Inst = new Profile();
	private Dictionary<string, string> mapValues = new Dictionary<string, string>();
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
			if (reader.IsStartElement("String") && !reader.IsEmptyElement) {
				mapValues.Add(reader.GetAttribute("id"), reader.ReadString());
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

		foreach (KeyValuePair<string, string> pair in mapValues) {
			userNode = xmlDoc.CreateElement("String");
			XmlAttribute attribute; 
			attribute = xmlDoc.CreateAttribute("id");
			attribute.Value = pair.Key;
			userNode.Attributes.Append(attribute);
			userNode.InnerText = pair.Value;
			rootNode.AppendChild(userNode);
		}
		
		xmlDoc.Save(profileName);
	}
	
	public void SetValue(string pKey, string pValue)
	{
		if (!mapValues.ContainsKey (pKey)) {
			mapValues.Add (pKey, pValue);
		} else {
			mapValues[pKey] = pValue;
		}
	}

	public string GetValue(string pKey)
	{
		string temp = null;

		if(mapValues.TryGetValue(pKey, out temp)) {
			return temp;
		} else {
			return "";
		}
	}

	public bool GetBoolValue(string pKey)
	{
		string temp = null;
		
		if(mapValues.TryGetValue(pKey, out temp)) {
			if (temp.Equals("true"))
				return true;
		}
		return false;
	}


}
