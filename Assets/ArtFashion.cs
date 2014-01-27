using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

/// <summary>
/// Keeps track of the latest fashions in the world of arts.
/// </summary>
public class ArtFashion : MonoBehaviour {
	public bool ready;
	public List<ArtProperties> goodPs = new List<ArtProperties>();
	public List<ArtProperties> badPs = new List<ArtProperties>();

	// Use this for initialization
	void Start () {
		goodPs.Add (ArtProperties.AweInducing);
		goodPs.Add (ArtProperties.Dynamic);
		goodPs.Add (ArtProperties.Extraordinary);
		goodPs.Add (ArtProperties.Glowing);
		goodPs.Add (ArtProperties.Inventive);
		goodPs.Add (ArtProperties.Scintillating);
		goodPs.Add (ArtProperties.Serene);
		goodPs.Add (ArtProperties.Sublime);
		goodPs.Add (ArtProperties.True);

		badPs.Add (ArtProperties.Abstruse);
		badPs.Add (ArtProperties.Aggravating);
		badPs.Add (ArtProperties.Boring);
		badPs.Add (ArtProperties.Childish);
		badPs.Add (ArtProperties.Derivative);
		badPs.Add (ArtProperties.Fishy);
		badPs.Add (ArtProperties.Infuriating);
		badPs.Add (ArtProperties.Nightmarish);
		badPs.Add (ArtProperties.Obtuse);
		badPs.Add (ArtProperties.Overdone);
		badPs.Add (ArtProperties.Pretentious);
		badPs.Add (ArtProperties.Redundant);

		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Abstract);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Artificial);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Cute);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Dickensian);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Disturbing);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Ephemeral);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Fractured);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Grotesque);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Impressionistic);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Lifelike);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Manichean);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Modern);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Naive);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Plain);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Plump);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Primitive);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Restrained);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Severe);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Shocking);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Staccato);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Tesselated);
		(Random.Range (0, 2) == 0 ? goodPs : badPs).Add (ArtProperties.Titillating);

		ready = true;
	}
}
