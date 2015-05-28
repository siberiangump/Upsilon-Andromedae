using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapName : TextGraber {

	MapModel map;

	public override void Grab ()
	{
		if (map!=null) {
			text.text = map.name.ToUpper();
		}
	}

	public override void SubscribingOnChanges(){
		if(map==null){
			map.Subscribe(UpdateText);
		}
	}

}
