using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour {
	float speed = 10f;
	Vector3 roteDirection;

	// Use this for initialization
	void Start () {
		roteDirection = new Vector3 (0, Random.Range (-1f, 1f), 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (speed * Time.deltaTime * roteDirection);
	}
}
