using UnityEngine;
using System.Collections;

public class List : MonoBehaviour {

	private GameObject[] items;
	public GameObject[] Items{
		set{
			items = value;
			Draw();
		}
		get{
			return items;
		}
	}

	public GameObject itemPrefab;

	public int displacement;

	[ContextMenu ("draw")]
	void Draw(){
		for(int i=0;i<items.Length;i++) {
			GameObject g = Instantiate(itemPrefab)as GameObject;
			g.transform.parent = this.transform;
			g.GetComponent<RectTransform>().localPosition = new Vector3(0,-i*displacement-displacement/2,0);
			g.BroadcastMessage("Init",items[i],SendMessageOptions.DontRequireReceiver);
		}
	}
}
