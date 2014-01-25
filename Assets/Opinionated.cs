using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Opinionated : MonoBehaviour {
	public Dictionary<ArtProperties, float> opinions = new Dictionary<ArtProperties, float>();
	public bool observing = false;
	public ArtObject observed;
	public float observationTime;
	public float minObservationTime = 2; public float maxObservationTime = 5;
	public float postObservationWait = 2;

	void RandomizeOpinions() {
		foreach (ArtProperties p in System.Enum.GetValues((typeof(ArtProperties)))) {
			opinions.Add(p, Random.Range(-1.0f, 1.0f));
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
				ArtProperties commentProperty = observed.properties[Random.Range(0, observed.properties.Count)];
				Statement st = GetComponent<StatementMaker>().State(commentProperty, observed, opinions[commentProperty]);
				gw.WaitUntilMove(st.lifespan);
				if (opinions[commentProperty] > 0) {
					iTween.PunchPosition(this.gameObject, new Vector3(0, -0.2f, 0), 0.5f);
				} else {
					iTween.ShakePosition(this.gameObject, new Vector3(0.05f, 0, 0), 0.5f);
				}
			}
		}
	}
}
