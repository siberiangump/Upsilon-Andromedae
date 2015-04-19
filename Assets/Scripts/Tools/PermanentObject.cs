using UnityEngine;
using System.Collections;

public class PermanentObject : MonoBehaviour {
	void Start () {
		Object.DontDestroyOnLoad(this.gameObject);
	}
}
