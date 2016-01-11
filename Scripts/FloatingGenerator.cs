using UnityEngine;
using System.Collections;

public class FloatingGenerator : MonoBehaviour {
	float genTime = -1f;
	float genPeriod = 4f;

	public GameObject floatingObjectPrefab;

	// Use this for initialization
	void Start () {
		genTime = -1f;
	}
	
	// Update is called once per frame
	void Update () {
		GenerationTimer ();
	}

	void GenerationTimer(){
		if (Time.time - genTime > genPeriod) {
			genTime = Time.time;
			GameObject floatObject = Instantiate(floatingObjectPrefab);
			floatObject.transform.parent = transform;
			Vector3 position = new Vector3(Random.Range (-1f, 1f) * 10f, Random.Range(-2f, 2f), Random.Range(1f, 10f));
			floatObject.transform.position = position;
			floatObject.GetComponent<Rigidbody>().mass = Random.Range (0.5f, 2f);
		}
	}
}
