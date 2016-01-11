using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {
	public float force = 0.00001f;
	public float radius = 1f;
	//public GameObject glowTube;
	public float smallForce = 0.000003f;
	public float smallRadius = 7f;
	//public GameObject pointLight;
	public GameObject sideBattery;

	float explosionTime = 0.2f;
	float explosionPeriod = 4f;

	bool grandExplosion = false;
	Vector3 explosionPos;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//RegularExplosion ();
	}

	void FixedUpdate() {
		GrandExplosion ();
	}

	void RegularExplosion() {
		if (Time.time - explosionTime > explosionPeriod) {
			Debug.Log ("Exploding");

			explosionTime = Time.time;
			Vector3 explosionPos = new Vector3(Random.Range(-10f, 10f), Random.Range (-5f, 5f), Random.Range(-10f, 10f));
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			
			foreach (Collider collider in colliders) {
				if (collider.attachedRigidbody != null) {
					collider.attachedRigidbody.AddExplosionForce(smallForce, explosionPos, smallRadius, -1, ForceMode.Impulse);
				}
			}
		}
	}

	void GrandExplosion() {
		if (grandExplosion) {
			grandExplosion = false;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
			
			foreach (Collider collider in colliders) {
				if (collider.attachedRigidbody != null) {
					collider.attachedRigidbody.AddExplosionForce(force, explosionPos, radius, 0.5f, ForceMode.Impulse);
				}
			}

			// Explosions for specific objects that requires special initial movements
			sideBattery.GetComponent<Rigidbody>().AddForce(force * new Vector3(-1f, 1f, 1f));
			//glow light turns off
			//glowTube.SetActive(false);
		//	pointLight.GetComponent<lightController>().turnOff();
		}
	}

	public void FirstExplosion(Vector3 position) {
		grandExplosion = true;
		explosionPos = position;
	}
}
