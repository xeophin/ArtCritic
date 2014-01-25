using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

/// <summary>
///  A statement about an art object.
/// </summary>
public class Statement : MonoBehaviour {
	public float lifespan = 3.5f;
	public Vector3 offset = new Vector3(0, 0, 0);

	public ArtProperties property;
	public string text;
	public GalleryVisitor emitter;
	public ArtObject topic;
	public float opinion; // -1 to +1
	public List<GalleryVisitor> hasReacted = new List<GalleryVisitor>();
	public float age;
	public bool textDisplayed;

	public void Init (ArtProperties property, GalleryVisitor emitter, ArtObject topic, float opinion) {
		this.property = property;
		this.emitter = emitter;
		this.topic = topic;
		this.opinion = opinion;
		transform.position = emitter.transform.position + offset;
		text = "Hmm...";
		this.gameObject.GetComponentInChildren<TextMesh> ().text = "Hmm...";
		transform.localScale = new Vector3(0.0f, 0.0f, 1.0f);

		foreach (Challenge ch in FindObjectsOfType<Challenge> ()) {
			if (ch.victim == emitter && ch.topic == topic) {
				Destroy(ch.gameObject);
			}
		}

		if (opinion > 0) {
			emitter.GetComponent<Speaker> ().playGood ();
		} else {
			emitter.GetComponent<Speaker> ().playBad ();
		}
	}

	void Start () {
		Destroy (this.gameObject, lifespan);
	}
	
	// Update is called once per frame
	void Update () {
		age += Time.deltaTime;
		if (!textDisplayed) {
			Listeners ls = GetComponent<Listeners> ();
			if (ls.found) {
				GalleryVisitor pgv = GameObject.FindWithTag("Player").GetComponent<GalleryVisitor> ();
				if (ls.listeners.Contains(pgv)) {
					text = property.ToString () + "!";
					this.gameObject.GetComponentInChildren<TextMesh> ().text = text;
					transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
					iTween.PunchScale (this.gameObject, new Vector3 (1.1f, 1.1f, 1.0f), 0.5f);
				} else {
					text = "...";
					this.gameObject.GetComponentInChildren<TextMesh> ().text = "...";
					transform.localScale = new Vector3(0.67f, 0.67f, 1.0f);
				}
				textDisplayed = true;
			}
		}
	}
}
