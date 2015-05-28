using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SpaceBodyModel : EventEmiter {

	public int development=0;
	public int capability=0;
	public int playerId=0;
	public Sprite image;
	public string name;
	public string description;
	public Color color = new Color(1,1,1,0.51f);
	public Color Color{
		set{
			color = value;
			Changed();
		}
		get{
			return color;
		}
	}

	//[HideInInspector]
	public string prefab_name;


}
