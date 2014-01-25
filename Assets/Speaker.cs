using UnityEngine;
using System.Collections;

public class Speaker : MonoBehaviour {
	public AudioClip good;
	public AudioClip bad;
	public AudioClip agree;
	public AudioClip disagree;
	public AudioClip ask;

	public void playGood() {
		if (good != null) { GetComponent<AudioSource> ().PlayOneShot (good); }
	}

	public void playBad() {
		if (bad != null) { GetComponent<AudioSource> ().PlayOneShot (bad); }
	}

	public void playAgree() {
		if (agree != null) { GetComponent<AudioSource> ().PlayOneShot (agree); }
	}

	public void playDisagree() {
		if (disagree != null) { GetComponent<AudioSource> ().PlayOneShot (disagree); }
	}

	public void playAsk() {
		if (ask != null) { GetComponent<AudioSource> ().PlayOneShot (ask); }
	}
}
