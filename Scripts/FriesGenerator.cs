using UnityEngine;
using System.Collections;

public class FriesGenerator : MonoBehaviour {
	public GameObject fryPrefab;
	int xMax = 7;
	int zMax = 3;
	float xStep = 0.013f;
	float zStep = 0.008f;
	float yAmplitude = 0.01f;
	float yOffset = 0f;
	float xRotRange = 0.03f;
	float yRotRange = 0.2f;
	float zRotRange = 0.03f;
	public Vector3 startPosition;

	// Use this for initialization
	void Start () {
		GenerateFries();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GenerateFries() {
		for (int i = 0; i < xMax; i++) {
			for (int j = 0; j < zMax; j++) {
				float randnum = Random.Range(-1f,1f);
				GameObject fry = Instantiate(fryPrefab);
				fry.transform.parent = transform;
				fry.transform.localPosition = startPosition;
				fry.transform.position += xStep * i * -transform.right
						+ (yAmplitude * randnum + yOffset) * transform.up
						+ zStep * j * transform.forward;
				fry.transform.localRotation = new Quaternion(xRotRange * randnum, yRotRange * randnum, zRotRange * randnum, 1);

			}
		}
	}
}
