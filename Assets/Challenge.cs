using UnityEngine;
using System.Collections;

public class Challenge : MonoBehaviour {
	public int reputationLoss = 10;
	public ArtObject topic;
	public GalleryVisitor victim;
	public float remainingTime = 5.0f;

	public void Init(ArtObject topic, GalleryVisitor victim) {
		this.topic = topic;
		this.victim = victim;
	}

	public void Answer() {
		Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start () {
		iTween.PunchScale (this.gameObject, new Vector3 (1.1f, 1.1f, 1.0f), 0.5f);
	}

	// Update is called once per frame
	void Update () {
		remainingTime -= Time.deltaTime;
		if (remainingTime <= 0) {
			victim.ChangeReputation(-reputationLoss);
			Destroy (this.gameObject);
		}
	}
}
