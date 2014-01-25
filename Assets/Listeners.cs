using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Listeners : MonoBehaviour {
	public float listenRadius = 1.9f;
	public Vector3 offset = new Vector3 (-0.5f, 0.5f);
	public List<GalleryVisitor> listeners = new List<GalleryVisitor>();
	public bool found;

	// Use this for initialization
	void Start () {
		foreach (GalleryVisitor gv in FindObjectsOfType<GalleryVisitor> ()) {
			Vector3 dist = gv.transform.position - transform.position - offset;
			if (dist.sqrMagnitude <= listenRadius * listenRadius) {
				listeners.Add(gv);
			}
		}
		found = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
