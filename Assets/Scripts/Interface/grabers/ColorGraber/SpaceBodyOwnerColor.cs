using UnityEngine;
using System.Collections;

public class SpaceBodyOwnerColor : ColorGraber {

	SpaceBodyModel model;

	public override void CorrectTarget(){
		if (gmo == null) {
			gmo = this.transform.parent.gameObject;
			model=gmo.GetComponent<SpaceBodyModel>();
			if(model!=null) model.Subscribe(ModelChanged);
			
			while(model==null && gmo.transform.parent != null){
				gmo=gmo.transform.parent.gameObject;
				model=gmo.GetComponent<SpaceBodyModel>();
				model.Subscribe(ModelChanged);
			}
		}
	}

	public override void Grab ()
	{
		if(model){
			image.color = model.Color;
		}
	}

}
