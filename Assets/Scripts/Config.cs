using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Config:MonoBehaviour {

	private static Config instance;
	public static Config Instance{
		get{
			if(instance==null){
				instance = GameObject.FindObjectOfType<Config>();
				if(instance==null){
					GameObject gmo = new GameObject();
					instance = gmo.AddComponent<Config>();
					gmo.name = "Config";
				}
			}
			return instance;
		}
	}

	public Sprite[] avatars;

	//space body v
	public int noOwnerSpaceBodyCounterCooldown = 2;
	public int haveOwnerSpaceBodyCounterCooldown = 1;

	//line colors
	public Color attack = new Color(1,.5f,.5f,.5f);
	public Color regroup = new Color(.5f,1,.5f,.5f);
	public Color nonactive = new Color(1,1,1,.5f);
}
