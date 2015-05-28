using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSettingsUI : MonoBehaviour {

	public PlayerModel player;
	public ImageCollectionSwitcher images;
	public Image color;
	public Text name;

	void Start(){
		Draw();
	}

 	public void Draw(){
		if(!Validation()){
			return;
		}
		images.SetSpriteByIndex(player.avatar);
		color.color = player.color;
		name.text = player.name;
	}

	public void Change(){
		player.ChangePlayerModelProperty(name.text,images.GetSpriteIndex(),color.color);
		PlayerPrefs.SetString(PrefsDefine.player,PlayerModel.SerializeJSON(player));
	}

	bool Validation(){
		if(player==null){
			Debug.Log("no player",this.gameObject);
			return false;
		}
		if(color==null){
			Debug.Log("no color back image",this.gameObject);
			return false;
		}
		if(name==null){
			Debug.Log("no text field",this.gameObject);
			return false;
		}
		return true;
	}
}
