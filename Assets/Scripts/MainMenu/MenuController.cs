using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public PlayerModel user;

	void Start(){
		if(user == null) {
			user = GameMain.Instance.gameObject.GetComponent<PlayerModel>();
		}
	}

	public void StartGame(MatchModel match){
		//PlayerPrefs.SetString(PrefsDefine.game + PrefsDefine.current_map,id);
		//PlayerPrefs.SetString(PrefsDefine.player + 1 + PrefsDefine.name,user.name);
		//PlayerPrefs.SetString(PrefsDefine.player + 1 + PrefsDefine.color,user.color.ToString());
		//PlayerPrefs.SetString(PrefsDefine.player + 1 + PrefsDefine.avatar,user.avatar);
		match.AddPlayer(user);
		match.transform.parent = GameMain.Instance.gameObject.transform; 
		Application.LoadLevel("Game");
	}
}