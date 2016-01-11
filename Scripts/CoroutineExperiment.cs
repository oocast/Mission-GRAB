using UnityEngine;
using System.Collections;

public class CoroutineExperiment : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		StopCoroutine("Route");	
	}

	IEnumerator Route(){
		yield return null;
	}
}
