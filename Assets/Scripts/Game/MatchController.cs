using UnityEngine;
using System.Collections;

public class MatchController : MonoBehaviour {

	private static MatchController instance;
	public static MatchController Instance{
		get{
			if(instance==null){
				instance = FindObjectOfType<MatchController>();
				if(instance==null){
					GameObject gmo = new GameObject();
					gmo.name = "MatchController";
					gmo.tag = "MatchController";
					instance = gmo.AddComponent<MatchController>();
				} 
			}
			return instance;
		}
	}
	
	public GameObject mainUI;
	public IO io;
	public MatchFlags flags;
	public MatchModel model;

	//clean this
	public string test_map = "5531696e6a7d620e0022eb39";

	// Use this for initialization
	void Awake () {
		if(MatchFlags.Instance==null){
			flags = this.gameObject.AddComponent<MatchFlags>();
		}
		if(GameObject.FindGameObjectWithTag("MainController") == null){
			return;
		}
		io=IO.Instance;
		Init ();
	}

	[ContextMenu ("init")]
	void Init () {
		if(io==null){
			io=IO.Instance;
		}

		model = GameMain.Instance.GetComponentInChildren<MatchModel>();
		io.Load(model.map.id);

		if(mainUI){
			mainUI.BroadcastMessage("GameLoaded",SendMessageOptions.DontRequireReceiver);
		}else{
			Debug.Log("define game ui canvas",this.gameObject);
		}
	}

	public void StartMarch(){
		flags.Status = MatchFlags.state.play;
	}
}
