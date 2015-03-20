using UnityEngine;
using System.Collections;

public class UnitsAmount : TextGraber {

	int old = 0;
	GameSpaceBody planet;

	public override void CorrectTarget(){
		if (gmo == null) {
			gmo = this.transform.parent.gameObject;
			planet=gmo.GetComponent<GameSpaceBody>();

			while(planet==null && gmo){
				gmo=gmo.transform.parent.gameObject;
				planet=gmo.GetComponent<GameSpaceBody>();
			}
		}
	}

	public override void Grab (){
		if (planet == null) {
		}
		if (planet) {
			if (old != planet.units) {
				if (old > planet.units) {
					old--;
				}
				if (old < planet.units) {
					old++;
				}
			}
			text.text = old.ToString ();
		}
	}
}
