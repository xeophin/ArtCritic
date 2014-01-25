using UnityEngine;
using System.Collections;

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

  /// <summary>
  /// GUI stuff.
  /// </summary>
  void OnGUI ()
  {
    GUI.Label (positionOfReputationLabel, string.Format ("Current Reputation: {0}", visitor.reputation));
  }
}

