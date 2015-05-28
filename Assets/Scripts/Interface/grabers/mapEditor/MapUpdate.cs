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
			map.Subscribe(UpdateText);
		}
	}
	
}
