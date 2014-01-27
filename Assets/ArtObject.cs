using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class ArtObject : MonoBehaviour {
	public ArtFashion fashion;

	public int numPropertiesEach = 2;
	public List<ArtProperties> goodProperties = new List<ArtProperties>();
	public List<ArtProperties> badProperties = new List<ArtProperties>();
	public ArtProperties lastPropertyStated;

	public bool ready;

	public void RandomizeProperties() {
		for (int i = 0; i < numPropertiesEach; i++) {
			ArtProperties p;
			do {
				p = fashion.goodPs[Random.Range(0, fashion.goodPs.Count)];
			} while (goodProperties.Contains(p));
			goodProperties.Add(p);
			do {
				p = fashion.badPs[Random.Range(0, fashion.badPs.Count)];
			} while (badProperties.Contains(p));
			badProperties.Add(p);
		}
	}

	// Update is called once per frame
	void Update () {
		if (!ready && fashion.ready) {
			RandomizeProperties();
			ready = true;
		}
	}
}
