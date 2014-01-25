using System.Collections;
using UnityEngine;

/// <summary>
///  Common properties of both the player avatar and the NPCs.
/// </summary>
public class GalleryVisitor : MonoBehaviour
{
  public int reputation = 100;
  public bool randomizeRep = true;
  public int minRep = 20;
  public int maxRep = 100;

  public bool CanTalk ()
  {
    foreach (Statement st in FindObjectsOfType<Statement>()) {
      if (st.emitter == this) {
        return false;
      }
      Listeners ls = st.GetComponent<Listeners> ();
      if (!ls.found || ls.listeners.Contains (this)) {
        return false;
      }
    }
    return true;
  }

  public void RandomizeRep ()
  {
    reputation = Random.Range (minRep, maxRep);
  }
  // Use this for initialization
  void Start ()
  {
    if (randomizeRep) {
      RandomizeRep ();
    }

    // Collect all available artworks
    artworks = Object.FindObjectsOfType<ArtObject> ();
  }
  // Update is called once per frame
  void Update ()
  {
	
  }

  public void ChangeReputation (int delta)
  {
    reputation += delta;
  }

  #region Artwork List

  /// <summary>
  /// A list of all available artworks.
  /// </summary>
  static ArtObject[] artworks;

  public static ArtObject GetClosestArtwork (Vector3 position)
  {
    ArtObject result = artworks [0];
    float smallestDistance = float.PositiveInfinity;
    foreach (var item in artworks) {
      float tempDistance = Vector3.Distance (position, item.transform.position);
      if (tempDistance <= smallestDistance) {
        smallestDistance = tempDistance;
        result = item;
      }
    }

    return result;
  }

  public ArtObject GetClosestArtwork ()
  {
    return GetClosestArtwork (transform.position);
  }

  #endregion

}
