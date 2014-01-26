using UnityEngine;
using System.Collections.Generic;

public class InventoryOfStatements : MonoBehaviour
{
  List<Statement> inventory = new List<Statement> ();
  GalleryVisitor gv;

  public void HandleStatementMade (Statement st)
  {
    if (!inventory.Exists (o => o.property == st.property)) {
      inventory.Add (st);
    }
  }

  void Start ()
  {
    gv = GetComponent<GalleryVisitor> ();

    // Get GUIskin
    skin = Camera.main.GetComponent<GeneralRessources> ().Style;
  }

  void Update ()
  {

    foreach (Statement st in FindObjectsOfType<Statement>()) {
      Listeners ls = st.GetComponent<Listeners> ();
      if (ls.found && ls.listeners.Contains (gv) && !st.hasReacted.Contains (gv)) {
        HandleStatementMade (st);
        st.hasReacted.Add (gv);
      }
    }
  }

  #region List Management

  #endregion

  #region GUI

  GUISkin skin;
  Rect positionOfList = new Rect (1000f, 20f, 260f, 500f);
  Matrix4x4 oldMatrix;
  Vector2 scrollViewPosition = new Vector2 ();

  void OnGUI ()
  {
    if (!GetComponent<GalleryVisitor> ().CanTalk ()) {
      return;
    }

    GUI.skin = skin;

    // Setup GUI scaling
    oldMatrix = GUI.matrix;
    GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, GeneralRessources.Scale);

    //Show list
    GUILayout.BeginArea (positionOfList);
    GUILayout.BeginScrollView (scrollViewPosition);
    foreach (Statement item in inventory) {
      if (GUILayout.Button (item.text)) {
        ArtObject talkedAboutArtwork = gv.GetClosestArtwork ();
        GetComponent<StatementMaker> ().State (item.property, talkedAboutArtwork, item.opinion);
      }
    }
    GUILayout.EndScrollView ();
    GUILayout.EndArea ();

    // Reset GUI scaling
    GUI.matrix = oldMatrix; 
  }

  #endregion

}

