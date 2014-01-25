using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryOfStatements : MonoBehaviour
{
	List<Statement> inventory = new List<Statement>();

	public void HandleStatementMade(Statement st) {
		inventory.Add (st);
	}

	void Update() {
		GalleryVisitor gv = GetComponent<GalleryVisitor> ();
		foreach (Statement st in FindObjectsOfType<Statement>()) {
			Listeners ls = st.GetComponent<Listeners> ();
			if (ls.found && ls.listeners.Contains(gv) && !st.hasReacted.Contains(gv)) {
				HandleStatementMade(st);
				st.hasReacted.Add(gv);
			}
		}
	}

  #region List Management

  #endregion

  #region GUI

  Rect positionOfList = new Rect (1000f, 10f, 260f, 700f);
  Matrix4x4 oldMatrix;
  Vector2 scrollViewPosition = new Vector2 ();

  void OnGUI ()
  {
    // Setup GUI scaling
    oldMatrix = GUI.matrix;
    GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, GeneralRessources.Scale);

    //Show list
    GUILayout.BeginArea (positionOfList);
    GUILayout.BeginScrollView (scrollViewPosition);
    foreach (Statement item in inventory) {
      if (GUILayout.Button (item.text)) {
        // Here we say something
      }
    }
    GUILayout.EndScrollView ();
    GUILayout.EndArea ();

    // Reset GUI scaling
    GUI.matrix = oldMatrix; 
  }

  #endregion
}

