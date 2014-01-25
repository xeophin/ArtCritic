using UnityEngine;
using System.Collections;

/// <summary>
///  Common properties of both the player avatar and the NPCs.
/// </summary>
public class GalleryVisitor : MonoBehaviour {
	public int reputation = 100;
	public int minRep = 20;
	public int maxRep = 100;

	public void RandomizeRep() {
		reputation = Random.Range (minRep, maxRep);
	}

	// Use this for initialization
	void Start () {
		RandomizeRep ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeReputation(int delta) {
		reputation += delta;
	}
}
