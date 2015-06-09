using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Config:Singleton<Config>{
	
	public Sprite[] avatars;

	//time
	public int dayTimeInSeconds = 1;

	
	public byte haveOwnerSpaceBodyCounterCooldown = 1;
	public byte noOwnerSpaceBodyCounterCooldown = 2;


	//line colors
	public Color attack = new Color(1,.5f,.5f,.5f);
	public Color regroup = new Color(.5f,1,.5f,.5f);
	public Color nonactive = new Color(1,1,1,.5f);

	//prefabs 
	public GameObject patrol;
	public GameObject ship;

}
