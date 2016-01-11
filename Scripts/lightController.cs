using UnityEngine;
using System.Collections;

public class lightController : MonoBehaviour {
	//Light alert;
	public float alert=0;
	public float flashingSpeed=3f;
	float highIntensity = 1.5f;
	float lowIntensity = 1f;
	bool shakeAlready=false;
//	void colorToRed ();
	//void colorToWhite ();
	void turnOffTheLight(){
		Light[] child = GetComponentsInChildren<Light> ();
		foreach (Light lt in child) {
			lt.intensity-=0.5f;
		}
		if (child [0].intensity <= 0) {
			CancelInvoke();

		}
	}
	
	void turnOnTheLight(){
		Light[] child = GetComponentsInChildren<Light> ();
		foreach (Light lt in child) {
			lt.intensity+=0.1f;
		}
		if (child [0].intensity >= 1) {
			CancelInvoke();
		}
	}

	public void turnOn(){
		InvokeRepeating ("turnOnTheLight", 0f, 0.1f);
	}
	public void turnOff(){
		InvokeRepeating ("turnOffTheLight", 0f, 0.1f);
	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (GlobalEventLog.isCrash && !shakeAlready) {
			turnOff();
			shakeAlready=true;
		}
		if (GlobalEventLog.powerResume) {
			//turnOn();
		}

	}	

}
