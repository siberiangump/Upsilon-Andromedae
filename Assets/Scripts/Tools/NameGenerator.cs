using UnityEngine;
using System.Collections;

public static class NameGenerator {

	
	public static string gen_name(){
		string[] characters1 = new string[] {"b", "c", "d", "f", "g", "h", "i", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z"};
		string[] characters2 = new string[] {"a", "e", "o", "u"};
		string[] characters3 = new string[] {"br", "cr", "dr", "fr", "gr", "pr", "str", "tr", "bl", "cl", "fl", "gl", "pl", "sl", "sc", "sk", "sm", "sn", "sp", "st", "sw", "ch", "sh", "th", "wh"};
		string[] characters4 = new string[] {"ae", "ai", "ao", "au", "a", "ay", "ea", "ei", "eo", "eu", "e", "ey", "ua", "ue", "ui", "uo", "u", "uy", "ia", "ie", "iu", "io", "iy", "oa", "oe", "ou", "oi", "o", "oy"};
		string[] characters5 = new string[] {"turn", "ter", "nus", "rus", "tania", "hiri", "hines", "gawa", "nides", "carro", "rilia", "stea", "lia", "lea", "ria", "nov", "phus", "mia", "nerth", "wei", "ruta", "tov", "zuno", "vis", "lara", "nia", "liv", "tera", "gantu", "yama", "tune", "ter", "nus", "cury", "bos", "pra", "thea", "nope", "tis", "clite"};		
		
		
		int Random1 = Random.Range(0,characters1.Length);
		int Random2 = Random.Range(0,characters2.Length);
		int Random3 = Random.Range(0,characters3.Length);
		int Random4 = Random.Range(0,characters4.Length);	
		int Random5 = Random.Range(0,characters5.Length);
		
		
		string name = characters1[Random1] + characters2[Random2] + characters5[Random5];
		
		return name;
	}
}
