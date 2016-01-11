using UnityEngine;
using System.Collections;

public class SpaceshipSoundController : MonoBehaviour {
	public AudioSource shortSound;
	public AudioClip selectSound;
	float selectBeepInterval = 2f;
	float selectBeepTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ButtonSound ();
	}

	void ButtonSound(){
		if (Time.time - selectBeepTime > selectBeepInterval) {
			selectBeepTime = Time.time;
			selectBeepInterval = Random.Range (0.1f, 4f);
			shortSound.PlayOneShot (selectSound, 0.2f);
		}
	}
}
