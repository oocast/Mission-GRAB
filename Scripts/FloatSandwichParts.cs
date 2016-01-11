using UnityEngine;
using System.Collections;

public class FloatSandwichParts : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		int dir = Random.Range (-1, 2);
		//rb.AddForce (new Vector3 (100f * dir, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
