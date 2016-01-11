using UnityEngine;
using System.Collections;

public class EMLightController : MonoBehaviour {
	bool shakeAlready=false;
	bool startShining = false;
	void turnOffTheLight(){
		Light[] child = GetComponentsInChildren<Light> ();
		foreach (Light lt in child) {
			lt.intensity-=0.1f;
		}
		if (child [0].intensity <= 0) {

			CancelInvoke("turnOffTheLight");

		}
	}
	
	void turnOnTheLight(){
		Light[] child = GetComponentsInChildren<Light> ();
		foreach (Light lt in child) {
			lt.intensity+=0.1f;
		}
		if (child [0].intensity >= 1) {
			startShining=true;
			CancelInvoke("turnOnTheLight");
		}
	}
	
	public void turnOn(){
		InvokeRepeating ("turnOnTheLight", 1f, 0.1f);
	}
	public void turnOff(){
		InvokeRepeating ("turnOffTheLight", 0f, 0.1f);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startShining) {
			Light[] child = GetComponentsInChildren<Light> ();
			foreach (Light lt in child) {
				lt.intensity+=GlobalEventLog.sinValue*0.002f;
			}
		}
		if (GlobalEventLog.isCrash && !shakeAlready) {
			turnOn();
			shakeAlready=true;
		}
		if (GlobalEventLog.powerResume) {
			startShining=false;
			//turnOff();
		}
	}
}
