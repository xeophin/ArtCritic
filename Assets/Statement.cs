using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

/// <summary>
///  A statement about an art object.
/// </summary>
public class Statement : MonoBehaviour {
	public float lifespan = 5;
	public Vector3 offset = new Vector3(0, 0, 0);

	public ArtProperties property;
	public string text;
	public GalleryVisitor emitter;
	public ArtObject topic;
	public float opinion; // -1 to +1
	public List<GalleryVisitor> hasReacted = new List<GalleryVisitor>();
	public float age;

	public void Init (ArtProperties property, GalleryVisitor emitter, ArtObject topic, float opinion) {
		this.property = property;
		this.emitter = emitter;
		this.topic = topic;
		this.opinion = opinion;
		text = property.ToString () + "!";
		this.gameObject.GetComponentInChildren<TextMesh> ().text = text;
		transform.position = emitter.transform.position + offset;
	}

	void Start () {
		Destroy (this.gameObject, lifespan);
	}
	
	// Update is called once per frame
	void Update () {
		age += Time.deltaTime;
	}
}
