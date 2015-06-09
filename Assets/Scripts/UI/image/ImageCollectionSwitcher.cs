using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageCollectionSwitcher : MonoBehaviour {

	public Sprite[] sprites;
	public int index;

	void Start(){
		sprites = Config.Instance.avatars;
		string nm = this.GetComponent<Image>().sprite.name;
		index = 0;
		for(int i=0;i<sprites.Length-1;i++){
			if(sprites[i].name==nm){index=i;}
		}
	}

	public void Next(){
		ChangeIndex(1);
		this.GetComponent<Image>().sprite = sprites[index];
	}

	public void Previous(){
		ChangeIndex(-1);
		this.GetComponent<Image>().sprite = sprites[index];
	}

	public void SetSpriteByName(string name){
		for(int i=0;i<sprites.Length-1;i++){
			if(sprites[i].name==name){
				index=i;
			}
		}
		this.GetComponent<Image>().sprite = sprites[index];
	}

	public void SetSpriteByIndex(int i){
		index=i;
		if(index>sprites.Length-1){
			index=sprites.Length-1;
		}
		if(index<0){
			index=0;
		}
		this.GetComponent<Image>().sprite = sprites[index];
	}

	public string GetSpriteName(){
		return sprites[index].name;
	}

	public int GetSpriteIndex(){
		return index;
	}

	void ChangeIndex(int prop){
		index+=prop;
		if(index>sprites.Length-1){
			index=0;
		}
		if(index<0){
			index=sprites.Length-1;
		}
	}
}
