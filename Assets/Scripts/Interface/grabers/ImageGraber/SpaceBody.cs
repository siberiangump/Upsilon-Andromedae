using UnityEngine;
using UnityEngine.UI;

public class SpaceBody : ImageGraber {

	SpaceBodyModel model;
	
	public override void Grab (){
		if (model == null) {
			model = gmo.GetComponent<SpaceBodyModel>();
		}
		if (model) {
			image.sprite = model.image;
		}
	}

}
