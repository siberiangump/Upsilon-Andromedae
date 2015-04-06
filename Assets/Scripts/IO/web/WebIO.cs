using System; 
using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 

public class WebIO : MonoBehaviour{   

	public GameObject resp;

	void Start(){}
	
	public void GET(string url,GameObject reportTo)
	{
		WWW www = new WWW (url);
		resp = reportTo;
		StartCoroutine (WaitForRequest (www));

		//return www; 
	}
	
	public WWW POST(string url, Dictionary<string,string> post)
	{
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<String,String> post_arg in post)
		{
			form.AddField(post_arg.Key, post_arg.Value);
		}
		WWW www = new WWW(url, form);
		
		StartCoroutine(WaitForRequest(www));
		return www; 
	}
	
	private IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			resp.BroadcastMessage("Response",www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}