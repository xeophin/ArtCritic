using UnityEngine;
using System.Collections;

public class StatementResponder : MonoBehaviour {
	public float responseDelay = 1.3f;
	public int correctOpinionBonus = 20;
	public int incorrectOpinionMalus = -10;
	public int irrelevantMalus = -5;
	public int repeatMalus = -10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<GalleryWanderer> ().IsMoving ()) { return; }
		GalleryVisitor gv = GetComponent<GalleryVisitor> ();
		Statement[] sts = FindObjectsOfType<Statement> ();
		foreach (Statement st in sts) {
			if (st.emitter != gv &&
			    st.age >= responseDelay &&
			    st.GetComponent<Listeners> ().listeners.Contains(gv) &&
			    !st.hasReacted.Contains(gv))
			{
				st.hasReacted.Add(gv);
				Respond(st);
				break;
			}
		}
	}

	void Respond(Statement st) {
		int response = 0;

		if (st.opinion == GetComponent<Opinionated> ().opinions [st.topic]) {
			response = correctOpinionBonus;
		} else {
			response = incorrectOpinionMalus;
		}

		if (st.repeat) {
			response += repeatMalus;
		}

		if (!st.topic.goodProperties.Contains (st.property) && !st.topic.badProperties.Contains (st.property)) {
			response += irrelevantMalus;
		}

		if (response > 0) {
			GetComponent<Speaker> ().playAgree ();
		} else {
			GetComponent<Speaker> ().playDisagree ();
		}

		GalleryVisitor gv = GetComponent<GalleryVisitor> ();
		if (gv.reputation > st.emitter.reputation) {
			st.emitter.ChangeReputation(response);
		}
	}
}
