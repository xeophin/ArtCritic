using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class StatementMaker : MonoBehaviour {
	public GameObject statementPrefab;

	public Statement State(ArtProperties property, ArtObject topic, float opinion) {
		GameObject bubble = (GameObject) Instantiate (statementPrefab);
		bubble.GetComponent<Statement> ().Init (property, GetComponent<GalleryVisitor> (), topic, opinion);
		return bubble.GetComponent<Statement> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
