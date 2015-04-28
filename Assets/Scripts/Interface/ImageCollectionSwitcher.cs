using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageCollectionSwitcher : MonoBehaviour {

	public Sprite[] sprites;
	int index;

	void Start(){
		string nm = this.GetComponent<Image>().sprite.name;
		index = 0;
		for(int i=0;i<sprites.Length-1;i++){
			if(sprites[i].name==nm){index=i;}
		}
		Debug.Log(nm);
	}

	public void Next(){
		ChangeIndex(1);
		this.GetComponent<Image>().sprite = sprites[index];
	}

	public void Previous(){
		ChangeIndex(-1);
		this.GetComponent<Image>().sprite = sprites[index];
	}

	void ChangeIndex(int prop){
		index+=prop;
		if(index>sprites.Length-1)index=0;
		if(index<0)index=sprites.Length-1;
	}
}
