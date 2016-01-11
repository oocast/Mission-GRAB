using UnityEngine;
using System.Collections;

public class RadioController : FloatingObject {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {
		if (isReplacing) {
			ReplaceObject ();
		}
	}

	virtual protected void ReplaceObject(){
		base.ReplaceObject ();
		// replacing finish
		if (!isReplacing) {
			GlobalEventLog.radioFixed = true;
			Debug.Log("Radio Fixed");
		}
	}
}
