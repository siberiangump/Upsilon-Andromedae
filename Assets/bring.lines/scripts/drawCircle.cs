using UnityEngine;
using System.Collections;

public class drawCircle : MonoBehaviour {

	public float r;
	public float lineWight;
	public float theta_scale = 0.1f;
	public Material material;
	public Color c1;

	float old_r;
	float old_lineWight;
	float old_theta_scale;
	Color old_c1;


	float x,y;
	float PI=3.14f;

	LineRenderer lineRenderer;

	void Start(){
		lineRenderer = gameObject.AddComponent<LineRenderer>();
		if (material)
			lineRenderer.material = material;
		else
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.useWorldSpace = false;
	}

	void Draw () {

		old_r = r;
		old_lineWight = lineWight;
		old_theta_scale = theta_scale;
		old_c1 = c1;


		int size =Mathf.RoundToInt((2.0f * PI) / theta_scale); //Total number of points in circle.
		
	
		lineRenderer.SetColors(c1, c1);
		lineRenderer.SetWidth(lineWight, lineWight);
		lineRenderer.SetVertexCount(size +1);
		
		int i = 0;
		for(float theta = 0; theta < 2 * PI; theta += 0.1f) {
			x = r*Mathf.Cos(theta);
			y = r*Mathf.Sin(theta);
			
			Vector3 pos = new Vector3(x, y, 0);
			lineRenderer.SetPosition(i, pos);
			if(i==0)lineRenderer.SetPosition(size, new Vector3(pos.x,pos.y+0.01f,0));
			i+=1;
		}
	}

	public void ChangeRadius(float r){
		this.r = r;
	}
	// Update is called once per frame
	void Update () {
		if (old_r != r || old_lineWight != lineWight || old_theta_scale != theta_scale || old_c1 != c1)
						Draw ();
	}
}
