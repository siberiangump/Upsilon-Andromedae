
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpaceBodyModel))]
public class GameSpaceBody : EventEmiter {

	public int units = 0; 
	public GameObject UI;
	public byte cooldown;
	public Player owner = null;

	public GameObject ownerMonitor; 

	public bool needGain = false;
	public Status status = Status.none_active;
	public Status baseStatus = Status.none_active;

	SpaceBodyModel model;


	// Use this for initialization
	void Awake () {
		EventsSubscriptions();
		//getting own model
		model = this.GetComponent<SpaceBodyModel> ();
		if(owner){
			cooldown = Config.Instance.haveOwnerSpaceBodyCounterCooldown;
			model.Color = owner.model.color;
		}else {
			cooldown = Config.Instance.noOwnerSpaceBodyCounterCooldown;
		}
	}

	void EventsSubscriptions(){
		//subsctiption
		EventManager.Instance.Subscribe(EventDefine.space_body_selected,OnSpaceBodySelected);
		EventManager.Instance.Subscribe(EventDefine.space_body_unselected,OnSpaceBodyUnselected);
		EventManager.Instance.Subscribe(EventDefine.space_body_selected_as_target,OnSpaceBodySelectedAsTarget);

		TimeManager.Instance.SubscribeOnNewDayEvent(Gainer);
	}

	public void InitOwner(GameObject player){
		ownerMonitor = player;
		owner = player.GetComponent<Player>();
		owner.СonquerSpaceBody(this.gameObject);
		model.Color = owner.model.color;

		if(GameMain.ScreenOwner.GetComponent<Player>().playerId == player.GetComponent<Player>().playerId){
			baseStatus = Status.active;
		} else {
			baseStatus = Status.none_active;
		}
		status = baseStatus;
	}

	public void OnSpaceBodySelected(GameObject spaceBody){
		if(spaceBody.GetInstanceID() == this.gameObject.GetInstanceID() && status==Status.active){
				status = Status.selected;
		}else{
			if(transform.FindChild(spaceBody.name)!=null){
				status = Status.target;
			}
		}
	}

	public void OnSpaceBodyUnselected(GameObject spaceBody){
		status = baseStatus;
	}

	public void	OnSpaceBodySelectedAsTarget(GameObject spaceBody){
		if(status == Status.selected){
			if(transform.FindChild(spaceBody.name)!=null){
				Config c= Config.Instance;
				GameObject partol = Instantiate(c.patrol);
				partol.GetComponent<GamePatrol>().Init(this.gameObject,spaceBody,10);
				EventManager.Instance.Emit(EventDefine.space_body_unselected,this.gameObject);
			}
		}
	}
	
	void Gainer () {
		cooldown --;
		if (cooldown==0){
			if (units > model.capability){
				units = model.capability;
				Changed();
			}else if(units < model.capability){
				units += model.development;
				Changed();
			}
			if(owner){
				cooldown = Config.Instance.haveOwnerSpaceBodyCounterCooldown;
			}else {
				cooldown = Config.Instance.noOwnerSpaceBodyCounterCooldown;
			}
		}
	}

	public enum Status {selected,target,active,none_active};
}
