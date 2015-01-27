using UnityEngine;
using System.Collections;
using UnityEditor;

public class LandPlacement : MonoBehaviour {
	public GameObject[] roadList;
	public GameObject car;
	private Vector3 landNewPosition = new Vector3(0,0,0);
	public static LandPlacement Inst = new LandPlacement();
	private Sprite[] landSprites;
	void Start () {
		landSprites = Resources.LoadAll<Sprite>("Images/Lands");
	}
	private void ShuffleList(GameObject[] list)
	{
		GameObject temp;
		for (int i=0; i<list.Length-1; i++) 
		{
			temp=list[i+1];
			list[i+1]=list[i];
			list[i]=temp;
		}
	}
	private void PlaceNextLand(GameObject[] list)
	{
		float offset = 0;
		foreach (GameObject obj in list)
			offset += GetSpriteWidth (obj);

		float pos = list[0].transform.position.x;
		landNewPosition.x = (pos + offset);
		list[0].transform.position =landNewPosition;
		list[0].GetComponent<SpriteRenderer> ().sprite =GetRandomTexture();
		ShuffleList(list);
	}
	private Sprite GetRandomTexture()
	{
		int someRandomShit = Random.Range(0, landSprites.Length); 
		return landSprites[someRandomShit]; 
	}

	private float GetSpriteWidth(GameObject land)
	{
		return land.GetComponent<SpriteRenderer>().sprite.bounds.max.x - land.GetComponent<SpriteRenderer>().sprite.bounds.min.x;
	}
	void Update() 
	{
		if (car.transform.position.x > roadList[1].transform.position.x)
			PlaceNextLand (roadList);
	}
}
