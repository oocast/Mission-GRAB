using UnityEngine;
using System.Collections;

public class BatteryController : MonoBehaviour {
	public EMLightController emLightScript;
	public lightController lightScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PowerResume() {
		emLightScript.turnOff ();
		lightScript.turnOn ();
	}
}
