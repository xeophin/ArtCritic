using UnityEngine;
using System.Collections;

public class Challenger : MonoBehaviour {
	public float maxPlayerDist = 2.0f;
	public float maxArtDist = 3.0f;
	public int maxMoreReputation = 20;
	public GameObject challengePrefab;
	public float askChancePerSecond = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FindObjectOfType<Statement> () != null || FindObjectOfType<Challenge> () != null) { return; }

		GalleryWanderer gw = GetComponent<GalleryWanderer> ();
		GalleryVisitor gv = GetComponent<GalleryVisitor> ();

		GalleryVisitor pgv = GameObject.FindWithTag ("Player").GetComponent<GalleryVisitor> ();

		if (gv.reputation > pgv.reputation + maxMoreReputation) { return; }

		if (Random.Range(0.0f, 1.0f) > Time.deltaTime * askChancePerSecond) { return; }

		if ((transform.position - pgv.transform.position).sqrMagnitude <= maxPlayerDist * maxPlayerDist) {
			ArtObject ao = nearbyArt(pgv);
			if (ao != null) {
				GameObject cho = (GameObject) Instantiate(challengePrefab);
				cho.GetComponent<Challenge>().Init(ao, pgv);
				cho.transform.position = transform.position;
				gw.WaitUntilMove(cho.GetComponent<Challenge>().remainingTime);
			}
		}
	}

	ArtObject nearbyArt(GalleryVisitor pgv) {
		foreach (ArtObject ao in FindObjectsOfType<ArtObject> ()) {
			if ((transform.position - ao.transform.position).sqrMagnitude <= maxArtDist * maxArtDist &&
			    (pgv.transform.position - ao.transform.position).sqrMagnitude <= maxArtDist * maxArtDist)
			{
				return ao;
			}
		}
		return null;
	}
}
