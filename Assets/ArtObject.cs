using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class ArtObject : MonoBehaviour {
	public int numProperties = 3;
	public List<ArtProperties> properties = new List<ArtProperties>();

	public void RandomizeProperties() {
		System.Array aps = System.Enum.GetValues ((typeof(ArtProperties)));
		for (int i = 0; i < numProperties; i++) {
			properties.Add((ArtProperties) aps.GetValue(Random.Range(0, aps.Length)));
		}
	}

	// Use this for initialization
	void Start () {
		RandomizeProperties ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
