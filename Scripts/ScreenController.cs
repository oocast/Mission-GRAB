using UnityEngine;
using System.Collections;

public class ScreenController : MonoBehaviour {
	bool crashed=false;
	//Transform[] child;
	// Use this for initialization
	void Start () {
		//child =GetComponentsInChildren<Transform>();
		//transform.GetChild
	}
	
	// Update is called once per frame
	void EMMode(){
		transform.GetChild(1).gameObject.SetActive (true);

	}
	void NMMode(){
		transform.GetChild(1).gameObject.SetActive (false);
		transform.GetChild(0).gameObject.SetActive (true);

	}
	void Update () {
		if (GlobalEventLog.isCrash && crashed==false) {
			crashed=true;


			transform.GetChild(0).gameObject.SetActive(false);
			Invoke("EMMode",4f);
		}
		if (GlobalEventLog.powerResume) {

			Invoke("NMMode",0f);
		}
	}
}
