using UnityEngine;
using System.Collections;

public class HamburgerBouncingSoundController : MonoBehaviour {
	public AudioSource bouncingSounds;
	public AudioClip glassBounce;
	public AudioClip wallBounce;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.tag == "Spaceship Walls") {
			// bouncing glass
			if (transform.position.y > 2f){
				bouncingSounds.PlayOneShot(glassBounce, 0.1f);
			}
			// bouncing wall / floor
			else {
				bouncingSounds.PlayOneShot(wallBounce, 0.5f);
			}
		}
	}
}
