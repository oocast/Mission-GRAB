using UnityEngine;
using System.Collections;

public class SpaceshipOutboundController : MonoBehaviour {
	public float resumeSpeed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other) {
		Vector3 direction = transform.position - other.transform.position;
		other.attachedRigidbody.velocity = direction * resumeSpeed;
	}
}
