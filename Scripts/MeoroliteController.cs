using UnityEngine;
using System.Collections;

public class MeoroliteController : MonoBehaviour {
	public Transform target;
	Rigidbody rb;
	float speed = 10f;
	float hitTime;
	float collisionTime;
	bool asetroidStart = false;
	public AudioSource sound;

	public ExplosionController explosionScript;
	public RadioDialogueController dialogueScript;
	public ScreenController screenScript;

	// Use this for initialization
	void Start () {
		//target = new Vector3 (0.64f, 2.3f, 3.58f);
		rb = GetComponent<Rigidbody> ();
		hitTime = dialogueScript.GetScene3Length() + 0.3f;
	}

	void FixedUpdate (){
		if (GlobalEventLog.tutorialEnd && !asetroidStart) {
			asetroidStart = true;

			Vector3 direction = target.position - transform.position;
			float distance = direction.magnitude;
			direction.Normalize ();
			
			rb.AddForce (direction * distance / hitTime, ForceMode.VelocityChange);
			rb.AddTorque (direction * speed * 2, ForceMode.VelocityChange);
		}
	}

	// Update is called once per frame
	void Update () {
		if (GlobalEventLog.isCrash == true) {
		//	if (Time.time - collisionTime > 0.2f) {
		//		GlobalEventLog.isCrash = false;
		//	}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name == "MeteoColliderPad") {
			rb.isKinematic = true;
			transform.parent = GameObject.Find("SpaceShip").transform;

			explosionScript.FirstExplosion(collision.contacts[0].point);
			sound.PlayOneShot(sound.clip);
			GlobalEventLog.isCrash = true;
			GlobalEventLog.radioFixed = false;
			GlobalEventLog.joystickFixed = false;
			collisionTime = Time.time;
		}
	}
}
