using UnityEngine;
using System.Collections;

public class HamburgerController : MonoBehaviour {
	Rigidbody rb;
	public Transform hamburgerReplace;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddTorque(new Vector3(10f,4f,3f));
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {

	}

	void FinishTutorial() {
		// Start a disaster!!
		if (transform.position == hamburgerReplace.position) {
			GlobalEventLog.tutorialEnd = true;
		}
	}

}
