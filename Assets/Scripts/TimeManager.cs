using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TimeManager : Singleton<TimeManager> {

	public bool run = false;
	public float countCooldown;
	public UnityEvent OnNewDay;
	public int day = 0;

	protected override void OnSingletonAwake(){
		countCooldown = Config.Instance.haveOwnerSpaceBodyCounterCooldown;
		EventSubscription();
	}

	void EventSubscription(){
		EventManager.Instance.Subscribe(EventDefine.play,SetRunTrue);
		EventManager.Instance.Subscribe(EventDefine.pause,SetRunFalse);
	}
	
	void SetRunTrue(){
		run=true;
	}
	
	void SetRunFalse(){
		run=false;
	}

	// Update is called once per frame
	void Update () {
		if(!run){
			return;
		}
		Count();
	}

	void Count(){
		countCooldown -= Time.deltaTime;
		if (countCooldown<0){
			day++;
			InvokeOnNewDayEvent();
			countCooldown = Config.Instance.dayTimeInSeconds;
		}
	}

	public void SubscribeOnNewDayEvent(UnityAction action){
		if(OnNewDay==null)OnNewDay = new UnityEvent();
		OnNewDay.AddListener(action);
		action();
	}

	public void InvokeOnNewDayEvent(){
		if(OnNewDay==null){
			Debug.Log ("no listeners",this.gameObject); 
			return;
		}
		OnNewDay.Invoke();
	}

}
