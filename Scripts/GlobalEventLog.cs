using UnityEngine;
using System.Collections;

public class GlobalEventLog : MonoBehaviour {
	public static bool isCrash = false;
	public static float sinValue;
	// set to true when fake hand destroyed;
	public static bool gameStart = false;
	// lock for asteroid hit
	public static bool tutorialEnd = false;
	// switch light back to normal if true
	// else do nothing
	public static bool powerResume = false;
	public static bool radioFixed = true;
	public static bool joystickFixed = true;
	public static bool gameWin = false;

	float frequency = 10f;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		sinValue = Mathf.Sin(frequency * Time.time);
		if (isCrash && powerResume && radioFixed && joystickFixed) {
			gameWin = true;
		}
	}

	void FixedUpdate(){
	}
}
