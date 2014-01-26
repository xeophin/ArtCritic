using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using System;

public class StatementMaker : MonoBehaviour
{
  public GameObject statementPrefab;

  public event EventHandler<StatementEventArgs> StatementMade;

  protected virtual void OnStatementMade (StatementEventArgs e)
  {
    var handler = this.StatementMade;
    if (handler != null)
      handler (this, e);
  }

  public Statement State (ArtProperties property, ArtObject topic, float opinion)
  {
    GameObject bubble = (GameObject)Instantiate (statementPrefab);
    bubble.GetComponent<Statement> ().Init (property, GetComponent<GalleryVisitor> (), topic, opinion);
    Statement s = bubble.GetComponent<Statement> ();
    OnStatementMade (new StatementEventArgs (s));
    return s;
  }
  // Use this for initialization
  void Start ()
  {
	
  }
  // Update is called once per frame
  void Update ()
  {
	
  }
}
