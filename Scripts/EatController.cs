using UnityEngine;
using System.Collections;

public class EatController : MonoBehaviour {
	public RadioDialogueController dialogueScript;
	public AudioSource eatingSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Try to eat");
		if ((other.tag == "Hamburger" || other.tag == "Fry") && other.GetComponent<GrabbableObject>().IsGrabbed()) {
			if (GlobalEventLog.isCrash) {
				dialogueScript.StartScene7();
			}
			if (other.tag == "Hamburger" && !GlobalEventLog.tutorialEnd) {
				GameObject.Find ("Hamburger Replace").SetActive(false);
				GlobalEventLog.tutorialEnd = true;
			}
			eatingSound.Play();
			Destroy(other.gameObject);
		}
	}
}
