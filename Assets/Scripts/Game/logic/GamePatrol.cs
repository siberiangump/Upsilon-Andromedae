using UnityEngine;
using System.Collections;

public class GamePatrol : MonoBehaviour {

	public GameObject unitPrefab;

	public GameObject fromSpaceBody;
	public GameObject toSpaceBody;

	public int amount = 10;

	public int unitsReached = 0;
	public int unitsReleased = 0;

	public float sendCooldown = 0.3f;
	float cooldown; 

	public float possitionAccuracy = 0.3f;
	public float rotationAccuracy = 0.3f;

	public bool initializationWasComplete = false;

	// Use this for initialization
	void Start () {
		cooldown = sendCooldown;
//		fromSpaceBody = null;
//		toSpaceBody = null;
	}

	public void Init(GameObject from, GameObject to,int amount){
		fromSpaceBody = from;
		toSpaceBody = to;
		this.amount = amount;
		initializationWasComplete=true;
	}

	// Update is called once per frame
	void Update () {
		if(!initializationWasComplete){
			return;
		}
		if(cooldown<=0 && amount-unitsReleased>0){
			Vector3 startPosition = new Vector3(
				fromSpaceBody.transform.position.x+Random.Range(-possitionAccuracy,possitionAccuracy),
				fromSpaceBody.transform.position.y+Random.Range(-possitionAccuracy,possitionAccuracy),
				fromSpaceBody.transform.position.z+Random.Range(-possitionAccuracy,possitionAccuracy));

			Quaternion startAngle = AngelTool.FaceObject(fromSpaceBody.transform.position,toSpaceBody.transform.position,FacingDirection.RIGHT);
			startAngle = new Quaternion(startAngle.x,startAngle.y,startAngle.z+Random.Range(-rotationAccuracy,rotationAccuracy),startAngle.w);
			GameObject unit = Instantiate(unitPrefab,startPosition,startAngle)as GameObject;
			unit.GetComponent<GameUnit>().Init(toSpaceBody,fromSpaceBody.GetComponent<SpaceBodyModel>().color,UnitReachedTarget);
			unitsReleased += 1;
			cooldown = sendCooldown;
		}else {
			cooldown -= Time.deltaTime;
		}
	}

	void UnitReachedTarget(){
		unitsReached++;
		if( unitsReached == amount ) {
			Destroy(this.gameObject);
		}
	}
	
}
