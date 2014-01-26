using UnityEngine;
using System.Collections;
using System.Security.AccessControl;

/// <summary>
/// Show reputation on GUI.
/// </summary>
[RequireComponent (typeof(GalleryVisitor))]
public class ShowReputationOnGUI : MonoBehaviour
{
  /// <summary>
  /// Reference to the visitor.
  /// </summary>
  GalleryVisitor visitor;
  readonly Rect positionOfReputationLabel = new Rect (20f, 20f, 200f, 30f);

  void Start ()
  {
    // Get reference to gallery visitor
    visitor = GetComponent<GalleryVisitor> ();
  }

  #region GUI

  Matrix4x4 oldMatrix;

  /// <summary>
  /// GUI stuff.
  /// </summary>
  void OnGUI ()
  {
    oldMatrix = GUI.matrix;

    GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, GeneralRessources.Scale);

    GUI.Label (positionOfReputationLabel, string.Format ("Current Reputation: {0}", visitor.reputation));
    GUI.matrix = oldMatrix;
  }

  #endregion

}

