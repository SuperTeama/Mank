using UnityEngine;
using System.Collections;
public class GOOwner : MonoBehaviour {
	public float braking;
	public GameObject[] objectList;
	public string path;
	public void Lag(float x)
	{
		foreach (GameObject obj in objectList) 
			obj.transform.Translate(x*braking,0f,0f);
	}
	public void PlaceNextLand()
	{
		float offset = 0;
		foreach (GameObject obj in objectList)
			offset += GetSpriteWidth (obj);

		objectList [0].transform.Translate(offset,0f,0f);
		objectList[0].GetComponent<SpriteRenderer> ().sprite =GetRandomTexture();
		ShuffleList();
	}
	private void ShuffleList()
	{
		GameObject temp;
		for (int i=0; i<objectList.Length-1; i++) 
		{
			temp=objectList[i+1];
			objectList[i+1]=objectList[i];
			objectList[i]=temp;
		}
	}
	public void CheckThisPosition(float Xpos)
	{
		if ( Xpos > objectList[1].transform.position.x)	PlaceNextLand ();
	}
	private Sprite GetRandomTexture()
	{
		Sprite[] spriteList = Resources.LoadAll<Sprite> (path);
		int someRandomShit = Random.Range(0, spriteList.Length); 
		return spriteList[someRandomShit]; 
	}
	private float GetSpriteWidth(GameObject land)
	{
		return land.GetComponent<SpriteRenderer>().sprite.bounds.max.x - land.GetComponent<SpriteRenderer>().sprite.bounds.min.x;
	}
}
