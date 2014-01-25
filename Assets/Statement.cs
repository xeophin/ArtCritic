﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Statement : MonoBehaviour {
	public float lifespan = 5;

	public ArtProperties property;
	public string text;
	public GalleryVisitor emitter;
	public ArtObject topic;
	public float opinion; // -1 to +1
	public List<GalleryVisitor> hasReacted = new List<GalleryVisitor>();

	public void Init (ArtProperties property, string text, GalleryVisitor emitter, ArtObject topic, float opinion) {
		this.property = property;
		this.text = text;
		this.emitter = emitter;
		this.topic = topic;
		this.opinion = opinion;
	}

	void Start () {
		Destroy (this.gameObject, lifespan);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
