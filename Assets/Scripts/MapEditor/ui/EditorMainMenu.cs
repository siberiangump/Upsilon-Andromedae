using UnityEngine;
using System.Collections;

public class EditorMainMenu : MonoBehaviour {
	Animator animator;
	void Start(){
		animator = this.GetComponent<Animator> ();
	}

	public void SaveHover(){
		animator.SetInteger ("state", 1);
	}

	public void SaveClick(){
		animator.SetInteger ("state", 10);
	}

	public void ResumeHover(){
		animator.SetInteger ("state", 3);
	}

	public void ResumeIt(){
		animator.SetInteger ("state", -1);
	}

	public void ExitHover(){
		animator.SetInteger ("state", 4);
	}

	public void LoadHover(){
		animator.SetInteger ("state", 2);
	}

	public void LoadClick(){
		animator.SetInteger ("state", 20);
	}

	public void Normal(){
		animator.SetInteger ("state", 0);
	}

}
