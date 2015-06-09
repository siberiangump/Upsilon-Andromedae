using UnityEngine;
using System.Collections;

public class UITriggerButton : MonoBehaviour {

	public GameObject target;

	public void Clicked(){
		target.SetActive (!target.activeSelf);
	}
}
