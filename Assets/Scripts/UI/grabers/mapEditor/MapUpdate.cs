using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapUpdate : TextGraber {

	MapModel map;

	public override void Grab ()
	{
		if (map) {
			text.text = map.lastSave;
		}
	}
	
	public override void SubscribingOnChanges(){
		if(map==null){
			CorrectTarget();
		}
		if(map!=null){
			map.Subscribe(UpdateText);
		}

	}

	public override void CorrectTarget(){
		map = gmo.GetComponent<MapModel>();
	}
}
