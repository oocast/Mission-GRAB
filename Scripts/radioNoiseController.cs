using UnityEngine;
using System.Collections;

public class radioNoiseController : MonoBehaviour {
	bool crashed=false;
	bool pwresumed=false;
	// Use this for initialization
	void Start () {
	
	}
	void randomDistort(){
		GetComponent<AudioDistortionFilter> ().distortionLevel = Random.Range(0,0.8f);

	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalEventLog.isCrash && crashed == false) {
			crashed=true;
			GetComponent<AudioSource>().Play();	
			InvokeRepeating("randomDistort",0f,1f);
		
		}
		if (GlobalEventLog.isCrash && GlobalEventLog.radioFixed && pwresumed==false) {
			pwresumed=true;
			GetComponent<AudioSource>().Stop();	
		}
	}
}
