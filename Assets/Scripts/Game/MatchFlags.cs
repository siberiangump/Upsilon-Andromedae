using UnityEngine;
using System.Collections;

public class MatchFlags : MonoBehaviour {

	state status = state.pause;
	public state Status{
		get{
			return status;
		}
		set{
			if(value == state.play){
				EventManager.Instance.Emit(EventDefine.play);
				this.status = value;
			}else if(value == state.pause){
				EventManager.Instance.Emit(EventDefine.pause);
				this.status = value;
			}else if(value == state.over){
				EventManager.Instance.Emit(EventDefine.over);
				this.status = value;
			}
		}
	}

	private static MatchFlags instance;
	public static MatchFlags Instance{
		get{
			if(instance==null){
				instance = GameObject.FindObjectOfType<MatchFlags>();
			}
			return instance;
		}
	}

	public enum state {pause, play, over}
}
