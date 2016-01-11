using UnityEngine;
using System.Collections;

public class ReplaceLightController : MonoBehaviour {
	protected Light light;
	public float max = 1.3f;
	public float min = 0.7f;

	float amplitude;
	float offset;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
		amplitude = 0.5f * (max - min);
		offset = 0.5f * (max + min);
	}
	
	// Update is called once per frame
	void Update () {
		if (light.enabled) {
			float intensity = amplitude * GlobalEventLog.sinValue + offset;
			light.intensity = intensity;
		}
	}
}
