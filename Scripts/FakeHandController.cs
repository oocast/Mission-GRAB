using UnityEngine;
using System.Collections;

public class FakeHandController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy() {
		GlobalEventLog.gameStart = true;
		Debug.Log ("Game Start!");
	}
}
