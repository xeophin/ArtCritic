using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Opinionated : MonoBehaviour {
	public Dictionary<ArtObject, bool> opinions = new Dictionary<ArtObject, bool>();
	public bool observing = false;
	public ArtObject observed;
	public float observationTime;
	public float minObservationTime = 2; public float maxObservationTime = 5;
	public float postObservationWait = 2;
	public bool preventRepeats;

	void RandomizeOpinions() {
		foreach (ArtObject ao in FindObjectsOfType<ArtObject> ()) {
			opinions[ao] = Random.Range(0, 2) == 0;
		}
	}

	// Use this for initialization
	void Start () {
		RandomizeOpinions ();
	}
	
	// Update is called once per frame
	void Update () {
		GalleryWanderer gw = GetComponent<GalleryWanderer> ();
		if (gw.IsMoving () || gw.observing == null || observed == gw.observing) { return; }

		if (!observing) {
			observing = true;
			observationTime = Random.Range(minObservationTime, maxObservationTime);
		}

		if (GetComponent<GalleryVisitor> ().CanTalk () && FindObjectOfType<Challenge> () == null) {
			observationTime -= Time.deltaTime;

			if (observationTime <= 0) {
				gw.WaitUntilMove(postObservationWait);
				observed = gw.observing;
				List<ArtProperties> ps = (opinions[observed] ? observed.goodProperties : observed.badProperties);
				ArtProperties commentProperty = ps[Random.Range(0, ps.Count)];
				if (preventRepeats) {
					commentProperty = ps[(ps.IndexOf(observed.lastPropertyStated) + 1) % ps.Count];
				}
				Statement st = GetComponent<StatementMaker> ().State(commentProperty, observed, opinions[observed]);
				gw.WaitUntilMove(st.lifespan);
			}
		}
	}
}
