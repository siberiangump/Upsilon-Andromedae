using UnityEngine;
using System.Collections;
using SimpleJSON;
using System.IO;
using System;
using System.Net;
using System.Net.Security;

[RequireComponent (typeof (MapModel))]
[RequireComponent (typeof (IO))]
public class EditorMain : MonoBehaviour {
	
	private string prefix = "editor";

	MapModel map;
	IO io;

	public void LoadMap(){

		io.Load (map.id);

	}

	public void New(){

		map.id = io.Create (map.name);
		map.name = io.lastName;
		map.lastSave = io.lastSave;

		PlayerPrefs.SetString (PrefsDefine.editor + PrefsDefine.current_map,map.id);

	} 

}
