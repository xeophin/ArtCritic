using UnityEngine;
using System.Collections;

public class StatementResponder : MonoBehaviour {
	public float responseDelay = 1.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<GalleryWanderer> ().IsMoving ()) { return; }
		GalleryVisitor gv = GetComponent<GalleryVisitor> ();
		Statement[] sts = FindObjectsOfType<Statement> ();
		foreach (Statement st in sts) {
			if (st.emitter != gv && st.age >= responseDelay && !st.hasReacted.Contains(gv)) {
				st.hasReacted.Add(gv);
				Respond(st);
				break;
			}
		}
	}

	void Respond(Statement st) {
		float response = st.opinion * GetComponent<Opinionated> ().opinions [st.property];
		if (response > 0) {
			iTween.PunchPosition(this.gameObject, new Vector3(0, -0.2f, 0), 0.5f);
		} else {
			iTween.ShakePosition(this.gameObject, new Vector3(0.05f, 0, 0), 0.5f);
		}
	}
}
