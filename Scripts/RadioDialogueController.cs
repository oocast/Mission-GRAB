using UnityEngine;
using System.Collections;

public class RadioDialogueController : MonoBehaviour {
	AudioSource radioVoice;
	bool crashed=false;
	bool rdresume=false;
	public AudioClip[] scene1;
	public AudioClip[] scene2;
	public AudioClip[] scene3;
	public AudioClip[] scene4; // Fixing radio
	public AudioClip[] scene5; // Radio fixed
	public AudioClip[] scene6;
	public AudioClip[] scene7;
	public AudioClip[] scene8;
	public AudioClip[] scene9;
	public AudioClip shortNoise;
	float earlyend = 0.35f;
	float noiseVolume = 0.1f;
	float speakingVolume=1f;
	bool scenePlaying = false;
	bool scene7Allowed = false;
	bool scene6Played = false;
	int currentScene = 1;

	// Use this for initialization
	void Start () {
		radioVoice = GetComponent<AudioSource>();

	}

	void noiseMixer(){
		if (GlobalEventLog.isCrash && crashed == false) {
			crashed=true;
			GetComponent<AudioDistortionFilter>().distortionLevel=1f;
			radioVoice.volume=0.5f;
			speakingVolume=0.2f;
		}
		if (GlobalEventLog.radioFixed && rdresume == false && GlobalEventLog.isCrash) {
			rdresume=true;
			GetComponent<AudioDistortionFilter>().distortionLevel=0.97f;
			radioVoice.volume=1f;
			speakingVolume=1f;
		}

	}
	// Update is called once per frame
	void Update () {
		UpdateCurrentScene();
		noiseMixer ();
		TryStartCurrentScene();
	}

	void UpdateCurrentScene() {
		// Scene 1 and 2 are automatic
		// Scene 3
		if (GlobalEventLog.tutorialEnd) {
			if (currentScene < 3) {
				// TODO: configure the meorolite speed, since finishing time is fixed
				for (int i = 1; i < 3; i++)
					StopCoroutine("PlayScene" + currentScene);
				currentScene = 3;
				scenePlaying = false;
				radioVoice.Stop();
			}
		}

		if (GlobalEventLog.isCrash) {
			if (currentScene == 3) {
				StopCoroutine("PlayScene3");
				currentScene = 4;
				scenePlaying = false;
				radioVoice.Stop();
			}
		}

		// Scene 5 and 6
		if (GlobalEventLog.radioFixed && GlobalEventLog.isCrash) {
			if (currentScene == 4) {
				StopCoroutine("PlayScene4");
				currentScene = 5;
				scenePlaying = false;
				radioVoice.Stop();
			}
		}

		if (GlobalEventLog.powerResume || GlobalEventLog.joystickFixed) {
			if (currentScene == 6) {
				StopCoroutine("PlayScene6");
				currentScene = 8;
				scenePlaying = false;
				radioVoice.Stop();
			}
		}

		// 
		if (GlobalEventLog.powerResume
		    && GlobalEventLog.radioFixed
		    && GlobalEventLog.joystickFixed) {
			if (currentScene == 6 || currentScene == 8) {
				StopCoroutine("PlayScene6");
				StopCoroutine("PlayScene8");
				currentScene = 9;
				scenePlaying = false;
			}
		}
	}

	void TryStartCurrentScene() {
		if (!scenePlaying) {
			switch(currentScene) {
			case 1:
				StartCoroutine("PlayScene1");
				break;
			case 2:
				StartCoroutine("PlayScene2");
				break;
			case 3:
				StartCoroutine("PlayScene3");
				break;
			case 4:
				StartCoroutine("PlayScene4");
				break;
			case 5:
				StartCoroutine("PlayScene5");
				break;
			case 6:
				StartCoroutine("PlayScene6");
				break;
			case 8:
				StartCoroutine("PlayScene8");
				break;
			case 9:
				StartCoroutine("PlayScene9");
				break;
			default:
				break;
			}
		}
	}

	// Hamburger 1
	IEnumerator PlayScene1(){
		Debug.Log ("Start Scene1");
		scenePlaying = true;
		yield return new WaitForSeconds(3.5f);
		int i = 0;
		do{
			radioVoice.PlayOneShot(shortNoise, noiseVolume);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene1[i],speakingVolume);
			yield return new WaitForSeconds(scene1[i].length);
			i++;
		} while(currentScene == 1 && i < scene1.Length);
		scenePlaying = false;
		if (currentScene == 1) 
			currentScene = 2;
		yield return null;
	}
	
	// Hamburger 2
	IEnumerator PlayScene2() {
		Debug.Log ("Start Scene2");
		scenePlaying = true;
		yield return new WaitForSeconds(6f);
		for (int i = 0; currentScene == 2 && i < scene2.Length; i++) {
			radioVoice.PlayOneShot(shortNoise, noiseVolume);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene2[i],speakingVolume);
			yield return new WaitForSeconds(scene2[i].length);
		}
		// not reset scenePlaying, deadend 1
		yield return null;
	}

	IEnumerator PlayScene3() {
		Debug.Log ("Start Scene3");
		scenePlaying = true;
		for (int i = 0; i < scene3.Length; i++) {
			radioVoice.PlayOneShot(shortNoise, noiseVolume);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene3[i],speakingVolume);
			yield return new WaitForSeconds(scene3[i].length);
		}
		// not reset scenePlaying, deadend 2
		yield return null;
	}

	public float GetScene3Length() {
		float result = 0f;
		foreach (AudioClip clip in scene3) {
			result += shortNoise.length - earlyend;
			result += clip.length;
		}
		return result;
	}

	IEnumerator PlayScene4() {
		Debug.Log ("Start Scene4");
		scenePlaying = true;
		scene7Allowed = true;
		yield return new WaitForSeconds(3f);
		scene7Allowed = false;
		radioVoice.PlayOneShot(scene4[0],speakingVolume);
		yield return new WaitForSeconds(scene4[0].length + 2f);
		radioVoice.PlayOneShot(scene4[1],speakingVolume);
		yield return new WaitForSeconds(scene4[1].length + 2f);
		radioVoice.PlayOneShot(scene4[2],speakingVolume);
		yield return new WaitForSeconds(scene4[2].length + 1f);
		radioVoice.PlayOneShot(scene4[3],speakingVolume);
		yield return new WaitForSeconds(scene4[3].length + 1f);
		radioVoice.PlayOneShot(scene4[4],speakingVolume);
		yield return new WaitForSeconds(scene4[4].length);
		radioVoice.PlayOneShot(scene4[5],speakingVolume);
		yield return new WaitForSeconds(scene4[5].length);
		radioVoice.PlayOneShot(scene4[6],speakingVolume);
		yield return new WaitForSeconds(scene4[5].length);
		// not reset scenePlaying, deadend 3
		scene7Allowed = true;
		yield return null;
	}

	// Radio fixed
	IEnumerator PlayScene5() {
		Debug.Log ("Start Scene5");
		scene7Allowed = false;
		scenePlaying = true;
		for (int i = 0; i < scene5.Length; i++) {
			radioVoice.PlayOneShot(shortNoise, 0.5f);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene5[i],speakingVolume);
			yield return new WaitForSeconds(scene5[i].length);
		}
		if (currentScene == 5) 
			currentScene = 6;
		scenePlaying = false;
		yield return null;
	}

	IEnumerator PlayScene6() {
		Debug.Log ("Start Scene6");
		scenePlaying = true;
		scene7Allowed = true;
		yield return new WaitForSeconds(7f);
		scene7Allowed = false;
		radioVoice.PlayOneShot(shortNoise, noiseVolume);
		yield return new WaitForSeconds(shortNoise.length - earlyend);
		radioVoice.PlayOneShot(scene6[0],speakingVolume);
		yield return new WaitForSeconds(scene6[0].length);
		scene7Allowed = true;
		yield return new WaitForSeconds(4f);
		scene7Allowed = false;
		for (int i = 1; i < scene6.Length; i++) {
			radioVoice.PlayOneShot(shortNoise, noiseVolume);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene6[i],speakingVolume);
			yield return new WaitForSeconds(scene6[i].length);
		}
		// not reset scenePlaying, deadend 4
		yield return null;
	}

	IEnumerator PlayScene7() {
		bool prevScenePlaying = scenePlaying;
		scenePlaying = true;
		scene7Allowed = false;
		radioVoice.PlayOneShot(shortNoise, noiseVolume);
		yield return new WaitForSeconds(shortNoise.length - earlyend);
		radioVoice.PlayOneShot(scene7[0],speakingVolume);
		yield return new WaitForSeconds(scene7[0].length);
		scenePlaying = prevScenePlaying;
		scene7Allowed = true;
		yield return null;
	}

	public void StartScene7() {
		if (scene7Allowed)
			StartCoroutine("PlayScene7");
	}

	IEnumerator PlayScene8() {
		Debug.Log ("Start Scene8");
		scenePlaying = true;
		scene7Allowed = true;
		yield return new WaitForSeconds(7f);
		scene7Allowed = false;
		for (int i = 1; i < scene8.Length; i++) {
			radioVoice.PlayOneShot(shortNoise, noiseVolume);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene8[i],speakingVolume);
			yield return new WaitForSeconds(scene8[i].length);
		}
		scene7Allowed = true;
		yield return null;
	}

	IEnumerator PlayScene9() {
		Debug.Log ("Start Scene9");
		scene7Allowed = false;
		scenePlaying = true;
		for (int i = 1; i < scene9.Length; i++) {
			radioVoice.PlayOneShot(shortNoise, noiseVolume);
			yield return new WaitForSeconds(shortNoise.length - earlyend);
			radioVoice.PlayOneShot(scene9[i],speakingVolume);
			yield return new WaitForSeconds(scene9[i].length);
		}
		yield return null;
	}

}
