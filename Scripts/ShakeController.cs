using UnityEngine;
using System.Collections;

public class ShakeController : MonoBehaviour {
	public float shake = 1f;
	public float shakeAmount=1f;
	public float decreaseFactor=0.1f;
	Vector3 offset;
	bool shakeAlready=false;
	//private Camera cam[];
	// Use this for initialization
	void Start () {
		offset = gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalEventLog.isCrash && !shakeAlready) {
			shake = 1f;
			shakeAlready=true;
		}

		if (shake > 0) {

			gameObject.transform.localPosition = Random.insideUnitSphere * shakeAmount+offset;

			shake -= Time.deltaTime * decreaseFactor;
			shakeAmount = shakeAmount > (decreaseFactor/1000) ? (shakeAmount - decreaseFactor/1000) : 0;
			
		} 
		else {
			shake = 0f;
		}
	}
}
