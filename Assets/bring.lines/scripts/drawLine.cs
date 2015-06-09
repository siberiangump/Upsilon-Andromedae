using UnityEngine;
using System.Collections;

[RequireComponent (typeof (LineRenderer))]
public class DrawLine : MonoBehaviour {

	public LineType type = LineType.FromTargetToTarget;
	public Transform from,to;
	public float lineWight;
	public Color fromColor;
	public Color toColor;
	public Material material;
	public float displasment;

	public bool init=false;
	public LineRenderer lineRenderer;
	LineType old_type;
	Transform old_from,old_to;
	float old_lineWight;
	Color old_fromColor,old_toColor;
	Material old_material;

	public bool dead=false;
	public GameObject markFrom,markTo; 

	void Start () {
		lineRenderer = this.gameObject.GetComponent<LineRenderer>();
		if (material)
			lineRenderer.material = material;
		else
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

		UpdateOldParametrs ();

	}

	public void Init(LineParametrData data){
		if(lineRenderer==null)lineRenderer = this.gameObject.AddComponent<LineRenderer>();
		if (material)
			lineRenderer.material = material;
		else
			lineRenderer.material = new Material(Shader.Find("Particles/Additive"));

		material = data.m;
		from = data.f;
		if(markFrom!=null){
			Destroy(markFrom);
		}
		markFrom = new GameObject ();
		markFrom.transform.parent = data.f;
		markFrom.tag = "mark";
		markFrom.name = data.t.name;

		to = data.t;
		if(markTo!=null){
			Destroy(markTo);
		}
		markTo = new GameObject ();
		markTo.transform.parent = data.t;
		markTo.tag = "mark";
		markTo.name = data.f.name; 

		fromColor = data.fc;
		toColor = data.tc;
		init = true;
		this.name = data.f.name + "-" + data.t.name;
		UpdateOldParametrs ();

	}

	void Draw(){
		if(type == LineType.FromTargetToTarget){

			lineRenderer.SetColors(fromColor,toColor);
			lineRenderer.SetWidth(lineWight, lineWight);
			lineRenderer.SetVertexCount(2);
			if(from!=null){
				if(displasment>0){
					Vector3 dir=from.position-to.position;
					Vector3 v=new Vector3 (from.position.x-(dir.normalized.x*0.1f*displasment),from.position.y-(dir.normalized.y*0.1f*displasment),from.position.z-(dir.normalized.z*0.1f*displasment));
					lineRenderer.SetPosition (0, v);
				}
				else lineRenderer.SetPosition (0, from.position);
			}
			if(to!=null){	
				if(displasment>0){
					Vector3 dir=to.position-from.position;
					Vector3 v=new Vector3 (to.position.x-(dir.normalized.x*0.1f*displasment),to.position.y-(dir.normalized.y*0.1f*displasment),to.position.z-(dir.normalized.z*0.1f*displasment));
					lineRenderer.SetPosition (1, v);
				}
				else lineRenderer.SetPosition (1, to.position);
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (init) {

			if(CheckParametrsChanged())
				UpdateOldParametrs();
			if(!dead)Draw();
					
		}
	}

	void UpdateOldParametrs(){
		old_type=type;
		old_from = from;
		old_to = to;
		old_fromColor = fromColor;
		old_toColor = toColor;
		old_material = material;

		if(markFrom!=null){
			Destroy(markFrom);
		}
		markFrom = new GameObject ();
		markFrom.transform.parent = from;
		markFrom.tag = "mark";
		markFrom.name = to.name;

		if(markTo!=null){
			Destroy(markTo);
		}
		markTo = new GameObject ();
		markTo.transform.parent = to;
		markTo.tag = "mark";
		markTo.name = from.name; 

		this.name = from.name + "-" + to.name;
	}

	bool CheckParametrsChanged(){
		if (from == null || to == null) {
			GameObject.DestroyImmediate (this.gameObject);
			dead=true;
			return false;	
		}
		if (old_type != type ||
		    old_from.gameObject.GetInstanceID() != from.gameObject.GetInstanceID() ||
		    old_to.gameObject.GetInstanceID() != to.gameObject.GetInstanceID() ||
		    old_fromColor != fromColor ||
		    old_toColor != toColor ||
		    old_material != material){
			return true;
		}
			
		return false;
	}

}

public enum LineType {FromTargetToTarget}
public struct LineParametrData{
	public LineType type;
	public Transform f,t;
	public float w;
	public Color fc,tc;
	public Material m;
	public LineParametrData(Transform from,Transform to,float wight,Material material){
		type = LineType.FromTargetToTarget;
		f = from;
		t = to;
		w = wight;
		fc = tc = Color.cyan;
		m = material;
	}
	public LineParametrData(Transform from,Transform to,float wight,Color color,Material material){
		type = LineType.FromTargetToTarget;
		f = from;
		t = to;
		w = wight;
		fc = tc = color;
		m = material;
	}
	public LineParametrData(Transform from,Transform to,float wight,Color color){
		type = LineType.FromTargetToTarget;
		f = from;
		t = to;
		w = wight;
		fc = tc = color;
		m = new Material(Shader.Find("Particles/Additive"));
	}
	public LineParametrData(Transform from,Transform to,float wight,Color fromColor,Color toColor){
		type = LineType.FromTargetToTarget;
		f = from;
		t = to;
		w = wight;
		fc = fromColor;
		tc = toColor;
		m = new Material(Shader.Find("Particles/Additive"));
	}
	public LineParametrData(Transform from,Transform to,float wight){
		type = LineType.FromTargetToTarget;
		f = from;
		t = to;
		w = wight;
		fc = tc = Color.gray;
		m = new Material(Shader.Find("Particles/Additive"));
	}
	public LineParametrData(Transform from,Transform to){
		type = LineType.FromTargetToTarget;
		f = from;
		t = to;
		w = 0.1f;
		fc = tc = Color.gray;
		m = new Material(Shader.Find("Particles/Additive"));
	}
}