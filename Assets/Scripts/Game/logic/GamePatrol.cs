using UnityEngine;
using System.Collections;

public class GamePatrol : MonoBehaviour {

	public GameObject unitPrefab;

	public GameObject fromSpaceBody;
	public GameObject toSpaceBody;

	public int amount = 10;

	public float sendCooldown = 0.3f;
	float cooldown; 

	public float possitionAccuracy = 0.3f;

	bool initializationWasComplete = false;

	// Use this for initialization
	void Start () {
		cooldown = sendCooldown;
		fromSpaceBody = null;
		toSpaceBody = null;
	}

	public void Init(GameObject from, GameObject to,int amount){
		fromSpaceBody = from;
		toSpaceBody = to;
		this.amount = amount;
	}

	// Update is called once per frame
	void Update () {
		if(!initializationWasComplete){
			return;
		}
		if(cooldown<=0){
			Vector3 startPosition = new Vector3(
				fromSpaceBody.transform.position.x+Random.Range(-possitionAccuracy,possitionAccuracy),
				fromSpaceBody.transform.position.y+Random.Range(-possitionAccuracy,possitionAccuracy),
				fromSpaceBody.transform.position.z+Random.Range(-possitionAccuracy,possitionAccuracy));

			GameObject unit = Instantiate(unitPrefab,startPosition,Quaternion.identity)as GameObject;
			unit.GetComponent<Motor>().GoTo(toSpaceBody);
		}
	}
}
