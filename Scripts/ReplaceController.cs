using UnityEngine;
using System.Collections;

public class ReplaceController : MonoBehaviour {
	public bool objectCheck = true;
	public GameObject attachment;
	//public GameObject glowLight;
	public bool tagCheck = false;
	public string attachmentTag;
	GameObject[] attachments;
	float attachmentEnterTime;
	float autoReplaceTime = 1.5f;

	// Use this for initialization
	void Start () {
		if (tagCheck) {
			attachments = GameObject.FindGameObjectsWithTag(attachmentTag);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		LightUp ();
	}
	
	void OnTriggerEnter(Collider other) {
		if (((objectCheck && other.gameObject == attachment) || (tagCheck && other.tag == attachmentTag))
		    && other.GetComponent<FloatingObject>() != null) {
			// This object is grabbed when entering the plate region
			if (other.gameObject.GetComponent<GrabbableObject>().IsGrabbed()) {
				other.gameObject.GetComponent<FloatingObject>().grabbedIn = true;
				attachmentEnterTime = Time.time;
				LightColorChanged(Color.cyan);
			}
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (((objectCheck && other.gameObject == attachment) || (tagCheck && other.tag == attachmentTag))
		    && other.GetComponent<FloatingObject>() != null) {
			if (other.gameObject.GetComponent<FloatingObject>().grabbedIn) {
				// grabbed in and then released
				if (!other.gameObject.GetComponent<GrabbableObject>().IsGrabbed()) {
					//other.attachedRigidbody.isKinematic = true;
					other.gameObject.GetComponent<FloatingObject>().StartReplace(transform);
		
				}
				else if (Time.time - attachmentEnterTime > autoReplaceTime) {
					other.gameObject.GetComponent<FloatingObject>().StartReplace(transform);
					attachmentEnterTime = Mathf.Infinity;
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if (((objectCheck && other.gameObject == attachment) || (tagCheck && other.tag == attachmentTag))
		    && other.GetComponent<FloatingObject>() != null) {
			// grabbed out, what are you thinking about?
			if (other.gameObject.GetComponent<GrabbableObject>().IsGrabbed()) {
				other.gameObject.GetComponent<FloatingObject>().grabbedIn = false;
			}
			LightColorChanged(Color.yellow);
		}

	}
	void LightColorChanged(Color clr ){

		//Transform child = transform.FindChild("Replace Spot Light");

		Light spotLight = GetComponentInChildren<Light> ();
		if (spotLight != null)
			spotLight.color = clr;
	}
	void LightUp() {
		if (objectCheck) {
			GrabbableObject gb = attachment.GetComponent<GrabbableObject>();
			// if grabbed, light up
			if (gb != null && gb.IsGrabbed() && !attachment.GetComponent<Rigidbody>().isKinematic) {
				Transform child = transform.FindChild("Replace Spot Light");
				Light[] lights = transform.GetComponentsInChildren<Light>();
				foreach (var light in lights) {
					light.enabled = true;
				}
			}
			// not grabbed, light off
			else {
				Transform child = transform.FindChild("Replace Spot Light");
				Light[] lights = transform.GetComponentsInChildren<Light>();
				foreach (var light in lights) {
					light.enabled = false;
				}
			}
		}
		else if (tagCheck) {
			bool lightUp = false;
			foreach (var obj in attachments) {
				GrabbableObject gb = obj.GetComponent<GrabbableObject>();
				// if grabbed, light up
				if (gb != null && gb.IsGrabbed() && !obj.GetComponent<Rigidbody>().isKinematic) {
					lightUp = true;
					break;
				}
				// not grabbed, light off
			}

			if (lightUp) {
				Transform child = transform.FindChild("Replace Spot Light");
				if (child != null) {
					child.gameObject.SetActive(true);
				}
			}
			else {
				Transform child = transform.FindChild("Replace Spot Light");
				if (child != null) {
					child.gameObject.SetActive(false);
				}
			}
		}
	}
}
