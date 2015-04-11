using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditorSpaceBodyUI : MonoBehaviour {

	MouseHolder mh;
	bool lockMove=false;
	public GameObject linePrefab;
	public Text uiname;
	public GameObject panel;
	public Text devepopment;
	public Text capability;
	public Text playerId;

	public ObjectPreview spaceBody;


	void Start(){
		if (!this.transform.parent) {
			DestroyImmediate (this.gameObject);		
		} else {
			spaceBody = this.transform.parent.gameObject.GetComponent<ObjectPreview>();
			UpdatePlayer();
			UpdateDevelopnet();
			UpdateCapability();
			if (uiname)
				uiname.text = this.transform.parent.gameObject.name;
			panel.SetActive(false);
		}
	} 

	public void LockMove(){
		lockMove=!lockMove;
	}

	public void Highlight(){
		PlayerPrefs.SetString("SelectedBody",this.transform.parent.name);
	}

	public void Clicked(){
		panel.SetActive (!panel.activeSelf);
	}

	public void Move(){
		if (lockMove)return;

		if (mh) {
			mh.target = this.transform.parent.gameObject;
		
		} else {
			mh=FindMouseHolder ();
			if(mh){
				mh.target = this.transform.parent.gameObject;
			
			}
		}
	}

	public void Remove(){
		GameObject.Destroy (this.transform.parent.gameObject);
	}

	public void Connect(){
		GameObject gmo = Instantiate (linePrefab)as GameObject;
		gmo.BroadcastMessage ("Init", new LineParametrData (this.transform.parent, gmo.transform));
		if (mh) {
			mh.target = gmo;
			mh.double_click = false;
		} else {
			mh=FindMouseHolder ();
			if(mh){
				mh.target = gmo;
				mh.double_click = false;
			}
		}
		panel.SetActive (false);
		gmo.AddComponent<ChangeLineTarget> ();
	}

	public MouseHolder FindMouseHolder(){
		return GameObject.Find ("Main Camera").GetComponent<MouseHolder>();
	}
	
	//capability
	public void IncreaseCapability(){
		spaceBody.capability+=10;
		UpdateCapability();
	}
	public void DecreaseCapability(){
		spaceBody.capability-=10;
		if(spaceBody.capability<0){
			spaceBody.capability=0;
		}
		UpdateCapability();
	}
	void UpdateCapability(){
		capability.text = spaceBody.capability + "";
	}

	//playerId
	public void IncreasePlayer(){
		spaceBody.playerId+=1;
		UpdatePlayer();
	}
	public void DecreasePlayer(){
		spaceBody.playerId-=1;
		if(spaceBody.playerId<0){
			spaceBody.playerId=0;
		}
		UpdatePlayer();
	}
	void UpdatePlayer(){
		if(spaceBody.playerId>0){
			playerId.text = spaceBody.playerId + "";
		}else playerId.text = "*";
	}

	//development
	public void IncreaseDevelopment(){
		spaceBody.development+=1;
		UpdateDevelopnet();
	}
	public void DecreaseDevelopment(){
		spaceBody.development-=1;
		UpdateDevelopnet();
	}
	void UpdateDevelopnet(){
		devepopment.text = spaceBody.development + "";
	}

}
