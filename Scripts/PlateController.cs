using UnityEngine;
using System.Collections;

public class PlateController : MonoBehaviour {

	public float plateHideTime = 5f;

	// Use this for initialization
	void Start () {
		transform.FindChild("PlateRigid").gameObject.SetActive (false);
		StartCoroutine("UnhideCoroutine");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
