using UnityEngine;
using System.Collections;

public class CrazyWallController : MonoBehaviour {
	float speed = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		Rigidbody rb = collision.collider.attachedRigidbody;
		if (rb != null) {
			//rb.AddForce(force * transform.up);
			rb.velocity += speed * transform.up;
		}
	}
}
