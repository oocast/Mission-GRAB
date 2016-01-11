using UnityEngine;
using System.Collections;

public class ColliderDebugger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log (name + "\t" + collision.collider.name + "\t parent: " + collision.collider.transform.parent);
	}
}
