using UnityEngine;
using System.Collections;

public class DebugDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponentInChildren<TextMesh> ().text = "Rep " + GetComponent<GalleryVisitor> ().reputation;
	}
}
