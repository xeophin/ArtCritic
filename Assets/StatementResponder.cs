using UnityEngine;
using System.Collections;

public class StatementResponder : MonoBehaviour {
	public float responseDelay = 1.3f;
	public float influence = 30;
	public float repeatMalus = 0.8f;

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
		float response = st.opinion * GetComponent<Opinionated> ().opinions [st.property];
		if (st.repeat) {
			response -= repeatMalus;
		}
		if (response > 0) {
			GetComponent<Speaker> ().playAgree ();
			//iTween.PunchPosition(this.gameObject, new Vector3(0, -0.15f, 0), 0.5f);
		} else {
			GetComponent<Speaker> ().playDisagree ();
			//iTween.ShakePosition(this.gameObject, new Vector3(0.08f, 0, 0), 0.5f);
		}

		GalleryVisitor gv = GetComponent<GalleryVisitor> ();
		if (gv.reputation > st.emitter.reputation) {
			st.emitter.ChangeReputation((int) (response * influence));
		}
	}
}
