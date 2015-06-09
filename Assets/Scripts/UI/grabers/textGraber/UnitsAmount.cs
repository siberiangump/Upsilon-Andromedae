using UnityEngine;
using System.Collections;

public class UnitsAmount : TextGraber {

	float changeCooldown = 0.5f;
	public int old = 0;
	public int units = 0;
	public GameSpaceBody planet;

	bool needUpdate = false; 

	public override void CorrectTarget(){
		if (gmo == null) {
			gmo = this.transform.parent.gameObject;
			planet=gmo.GetComponent<GameSpaceBody>();

			while(planet==null && gmo.transform.parent != null){
				gmo=gmo.transform.parent.gameObject;
				planet=gmo.GetComponent<GameSpaceBody>();
			}
		}
		if(planet!=null){
			planet.Subscribe(UpdateText);
		}
	}
	
	public override void Grab (){
		if (planet) {
			units = planet.units;
		}
		if(old == planet.units){
			needUpdate = true;
		}
	}

	public override void SubscribingOnChanges(){
		if (planet == null) {
			planet = gmo.GetComponent<GameSpaceBody>();
			planet.Subscribe(UpdateText);
		}
	}

	void Count(){
		if (old != units && changeCooldown < 0) {
			if (old > units) {
				old--;
				changeCooldown = .5f;
			}
			if (old < units) {
				old++;
				changeCooldown = .5f;
			}
			text.text = old.ToString ();
		}
		if(changeCooldown >= 0){
			changeCooldown-=Time.deltaTime;
		}

	}

	void Update(){
		Count();
	}
}
