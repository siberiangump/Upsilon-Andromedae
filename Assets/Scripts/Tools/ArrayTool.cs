using UnityEngine;
using System.Collections;

public static class ArrayTool {

	//
	// GameObject arrays
	//
	public static void Add(GameObject[] from,out GameObject[] to, GameObject gmo){
		if(CheckInArray(from, gmo)){
			to = from;
			return;
		}
		to = new GameObject[from.Length+1];
		for(int i=0;i<from.Length;i++){
			to[i] = from[i];
		}
		to[to.Length-1]=gmo;
	}

	public static void Remove(GameObject[] from,out GameObject[] to, GameObject gmo){
		if(!CheckInArray(from, gmo)){
			to = from;
			return;
		}
		to = new GameObject[from.Length-1];
		for(int i=0;i<from.Length;i++){
			if(gmo.GetInstanceID() != from[i].GetInstanceID()){
				to[i] = from[i];
			}
		}
		to[to.Length-1] = gmo;
	}

	public static bool CheckInArray(GameObject[] array,GameObject gmo){
		for(int i=0;i<array.Length;i++){
			if(gmo.GetInstanceID() == array[i].GetInstanceID()){
				return true;
			}
		} 
		return false;
	}
	
	//
	//String arrays
	//
	public static void Add(string[] from,out string[] to, GameObject gmo){
		to = new string[0];	
	}

	public static void Remove(string[] from,out string[] to, GameObject gmo){
		to = new string[0];	
	}
	
	public static bool CheckInArray(string[] array,string gmo){
		for(int i=0;i<array.Length;i++){
			if(gmo == array[i]){
				return true;
			}
		} 
		return false;
	}

}
