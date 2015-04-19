using UnityEngine;
using System.Collections;

public class LoadingView : MonoBehaviour {

	Animator a;

	void Awake(){
		a = gameObject.GetComponent<Animator>();
		if(a == null) Destroy(this.gameObject);
	}

	public void GameLoaded(){
		a.SetTrigger("loaded");
	}

	public void PlayerReady(){
		a.SetTrigger("ready");
	}
}
