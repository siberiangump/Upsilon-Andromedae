using UnityEngine;
using System.Collections;

public static class ColorTool {
	public static Color ParseColor (string col) {
		//Takes strings formatted with numbers and no spaces before or after the commas:
		// "1.0,1.0,.35,1.0"
		string c = col.Slice(5,-1);
		string[] strings = c.Split(","[0] );
		
		Color output = new Color(
			System.Single.Parse(strings[0]),
			System.Single.Parse(strings[1]),
			System.Single.Parse(strings[2]),
			System.Single.Parse(strings[3]));
		return output;
	}
	
	public static string Slice(this string source, int start, int end){
		if (end < 0) // Keep this for negative end support
		{
			end = source.Length + end;
		}
		int len = end - start;               // Calculate length
		return source.Substring(start, len); // Return Substring of length
	}
}