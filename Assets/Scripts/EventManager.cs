using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

	//for monitoring in editor
	public string[] declareted;
	public Dictionary <string,UnityEvent> dictionary; 

	public class UnityEventWithGameObject : UnityEvent<GameObject>{};
	public string[] declaretedWithGameObject;
	public Dictionary <string,UnityEventWithGameObject> dictionaryWithGameObject;

	//Dictionary <string,UnityEvent> dictionary; 

	private static EventManager instance;
	public static EventManager Instance{
		get{
			if(instance==null){
				instance = GameObject.FindObjectOfType<EventManager>();
				if(instance==null){
					GameObject gmo = new GameObject();
					instance = gmo.AddComponent<EventManager>();
					gmo.name = "EventManager";
				}
			}
			return instance;
		}
	}

	void Awake(){
		dictionary = new Dictionary<string,UnityEvent>();
		dictionaryWithGameObject = new Dictionary<string,UnityEventWithGameObject>();
		declareted = new string[0]; 
	}

	public void Subscribe(string eventName, UnityAction action){
		UnityEvent tempUEvent = null;
		if(!instance.dictionary.TryGetValue(eventName,out tempUEvent)){
			tempUEvent = new UnityEvent();
			instance.dictionary.Add(eventName, tempUEvent);
			//for monitoring in editor
			declareted = new string[dictionary.Keys.Count];
			dictionary.Keys.CopyTo(declareted, 0);
			//AddToDeclaretedEvents(eventName);
		}
		tempUEvent.AddListener(action);
	}
	
	public void UnSubscribe(string eventName, UnityAction action){
		UnityEvent tempUEvent = null;
		if(instance.dictionary.TryGetValue(eventName,out tempUEvent)){
			tempUEvent.RemoveListener(action);
		}
	}
	
	public void Emit(string eventName){
		UnityEvent tempUEvent = null;
		if(instance.dictionary.TryGetValue(eventName,out tempUEvent)){
			Debug.Log(eventName);
			tempUEvent.Invoke();
		}
	}

	//
	//UnityЕvent<GameObject> region
	//

	public void Subscribe(string eventName, UnityAction<GameObject> action){
		UnityEventWithGameObject tempUEvent = null;
		if(!instance.dictionaryWithGameObject.TryGetValue(eventName,out tempUEvent)){
			tempUEvent = new UnityEventWithGameObject();
			instance.dictionaryWithGameObject.Add(eventName, tempUEvent);
			//for monitoring in editor
			declaretedWithGameObject = new string[dictionaryWithGameObject.Keys.Count];
			dictionaryWithGameObject.Keys.CopyTo(declaretedWithGameObject, 0);
			//AddToDeclaretedEvents(eventName);
		}
		tempUEvent.AddListener(action);
	}

	public void UnSubscribe(string eventName, UnityAction<GameObject> action){
		UnityEventWithGameObject tempUEvent = null;
		if(instance.dictionaryWithGameObject.TryGetValue(eventName,out tempUEvent)){
			tempUEvent.RemoveListener(action);
		}
	}

	public void Emit(string eventName, GameObject gmo){
		UnityEventWithGameObject tempUEvent = null;

		if(instance!=null && 
		   instance.dictionaryWithGameObject!=null && 
		   instance.dictionaryWithGameObject.TryGetValue(eventName,out tempUEvent)){
			Debug.Log(eventName + "from",gmo);
			tempUEvent.Invoke(gmo);
		}
	}

}
