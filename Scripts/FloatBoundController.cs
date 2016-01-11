using UnityEngine;
using System.Collections;

public class FloatBoundController : MonoBehaviour {
	float attractionConstant = 10f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Floater") {
			Vector3 tangent = other.transform.position - transform.position;
			float distance = tangent.magnitude;
			float speed = Mathf.Sqrt (attractionConstant / distance);
			tangent = Vector3.Cross (tangent, new Vector3 (0f, 1f, 0f));
			tangent.Normalize();
			other.gameObject.GetComponent<Rigidbody>().velocity = speed * tangent;

		}
	}
}
