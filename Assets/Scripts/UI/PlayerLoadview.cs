using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLoadview : MonoBehaviour {

	public int index;
	public Image image;
	public Image color;
	PlayerModel model;

	// Use this for initialization
	void Awake () {
		if(GameMain.Instance==null){
			return;
		}
		model = GameMain.Instance.transform.GetComponentInChildren<MatchModel>().players[index];
		image.sprite = Config.Instance.avatars[model.avatar];
		color.color = model.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
