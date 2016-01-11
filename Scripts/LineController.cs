using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {
	//public GameObject lineEnd;
	LineRenderer line;
	public Transform[] lineJoint;
	// Use this for initialization
	void Start () {
		//Debug.Log ("hahaha");

		line = GetComponent<LineRenderer> ();
		//lineJoint = GetComponentsInChildren<Transform>();
		//Debug.Log (lineJoint.Length);
		line.SetVertexCount (lineJoint.Length);

	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0 ;i<lineJoint.Length; i++) {
			line.SetPosition(i,lineJoint[i].position);
			
		}
	}
}
