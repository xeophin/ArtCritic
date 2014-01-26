using UnityEngine;
using System.Collections;

public class Speaker : MonoBehaviour {
	public AudioClip good;
	public AudioClip bad;
	public AudioClip agree;
	public AudioClip disagree;
	public AudioClip ask;
	
	void Start() {

	}

	public void playGood() {
		if (good != null) { GetComponent<AudioSource> ().PlayOneShot (good); }
		PlayClip ("pGood");
	}

	public void playBad() {
		if (bad != null) { GetComponent<AudioSource> ().PlayOneShot (bad); }
		PlayClip ("pBad");
	}

	public void playAgree() {
		if (agree != null) { GetComponent<AudioSource> ().PlayOneShot (agree); }
		PlayClip ("pAgree");
	}

	public void playDisagree() {
		if (disagree != null) { GetComponent<AudioSource> ().PlayOneShot (disagree); }
		PlayClip ("pDisagree");
	}

	public void playAsk() {
		if (ask != null) { GetComponent<AudioSource> ().PlayOneShot (ask); }
		PlayClip ("pAsk");
	}

	void PlayClip(string name) {
		GetComponentInChildren<Animator> ().SetTrigger (name);
	}
}
