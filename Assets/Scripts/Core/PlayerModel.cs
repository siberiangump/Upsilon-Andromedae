using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using SimpleJSON;

public class PlayerModel : EventEmiter {
	
	public Color color;
	public string name;
	public int avatar;

	/// <summary>
	/// Changes the player model property and emit event about it.
	/// </summary>
	public void ChangePlayerModelProperty(string name, int avatar, Color color){
		this.color = color;
		this.name = name;
		this.avatar = avatar;
		Changed();
	}

	public static string SerializeJSON(PlayerModel player){
		if(player==null){
			Debug.Log("u pass null parametr");
			return "";
		}
		string json ="{\"name\":\""+player.name+
					"\",\"color\":" + player.color.ToString().Replace(",","|")+
					",\"avatar\":"+player.avatar+"}";
		Debug.Log(json);
		return 	json;
	}
	
	public static void ParseJSON(string json, PlayerModel result){
		Debug.Log(json);
		if(json==""){
			Debug.Log("u are new player, save some data");
			return;
		}
		var nodes = JSON.Parse(json);
		result.ChangePlayerModelProperty(
			nodes["name"].Value,
			nodes["avatar"].AsInt,
			ColorTool.ParseColor(nodes["color"].Value.Replace("|",",")));
		//result.name = nodes["name"].Value;
		//result.color = ColorExtensions.ParseColor(nodes["color"].Value.Replace("|",","));
		//result.avatar = nodes["avatar"].AsInt;
	}

	public static void Clone(PlayerModel from, PlayerModel to){
		to.avatar = from.avatar;
		to.color = from.color;
		to.name = from.name;
	}

}

