using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {
	// if this object is grabbed into plate region
	public bool grabbedIn;
	public bool isReplacing;
	float replaceSpeed = 100f;
	float floatingSpeedLimit = 10f;

	Transform replaceTartget;
	float replaceStartTime;
	Vector3 replaceStartPosition;
	Quaternion replaceStartRotation;
	bool crashed=false;
	float powerResumeTime;
	
	// Use this for initialization
	void Start () {
		isReplacing = false;
		grabbedIn = false;
		if (this.tag != "Hamburger") {
			GetComponent<Rigidbody> ().isKinematic = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalEventLog.isCrash && crashed == false) {
			crashed=true;
			GetComponent<Rigidbody> ().isKinematic = false;
		}
	}
	
	void FixedUpdate() {
		if (isReplacing) {
			ReplaceObject();
		}
		ScaleDownVelocity();

	}
	
	public void StartReplace() {
		isReplacing = true;
		grabbedIn = false;
		replaceStartPosition = transform.position;
		replaceStartRotation = transform.rotation;
		replaceStartTime = Time.time;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().isKinematic = true;
	}

	public void StartReplace (Transform target) {
		replaceTartget = target;
		StartReplace();
	}
	
	virtual protected void ReplaceObject(){
		float t = replaceSpeed * (Time.time - replaceStartTime);
		if (t > 1f) {
			isReplacing = false;
			//GetComponent<Rigidbody>().isKinematic = false;
		}
		t = Mathf.Clamp01 (t);
		transform.position = Vector3.Lerp (replaceStartPosition, replaceTartget.position, t);
		transform.rotation = Quaternion.Lerp (replaceStartRotation, replaceTartget.rotation, t);
		if (!isReplacing) {
			replaceTartget.gameObject.SetActive(false);
			FinishTutorial();
			ResumePower();
			FixRadio();
			FixLever();
		}
	}

	void FinishTutorial() {
		// I am a hamburger in place, start disaster!
		if (gameObject.name == "Hamburger") {
			GlobalEventLog.tutorialEnd = true;
		}
	}

	void ResumePower() {
		if (gameObject.name == "Battery Side") {
			GlobalEventLog.powerResume = true;
			Debug.Log ("Set powerResume trigger variable");
			GetComponent<BatteryController>().PowerResume();
		}
	}

	void FixRadio() {
		if (gameObject.name == "radio") {
			Debug.Log ("Radio Fixed");
			GlobalEventLog.radioFixed = true;
			Transform line = gameObject.transform.parent;
			gameObject.transform.parent = line.parent;
			Destroy(line.gameObject);
		}
	}

	void FixLever() {
		if (gameObject.name == "Joystick") {
			Debug.Log ("Lever Fixed");
			GlobalEventLog.joystickFixed = true;
		}
	}

	void ScaleDownVelocity() {
		var rb = GetComponent<Rigidbody>();
		if (rb.velocity.magnitude > floatingSpeedLimit) {
			rb.velocity *= .5f;
		}
	}
}
