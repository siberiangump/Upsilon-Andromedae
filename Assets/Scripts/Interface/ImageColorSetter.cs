using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageColorSetter : MonoBehaviour {
	
	public void SetImageColor(Image from){
		this.GetComponent<Image>().color = from.color; 
	}
}
