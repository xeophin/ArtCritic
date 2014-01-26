using System.Collections;
using UnityEngine;

/// <summary>
///  Common properties of both the player avatar and the NPCs.
/// </summary>
public class GalleryVisitor : MonoBehaviour
{
  public int reputation = 100;
  public bool randomizeRep = true;
  public int minRep = 40;
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
		ChangeReputation (0);
  }
  // Update is called once per frame
  void Update ()
  {
	
  }

 	public void ChangeReputation (int delta) {
		reputation += delta;
		//iTween.ScaleTo (transform.FindChild ("visitorSprite").FindChild ("head").gameObject, new Vector3 (reputation / 100f, reputation / 100f, 1.0f), 0.1f);
		transform.localScale = new Vector3 (0.8f + reputation / 500f, 0.8f + reputation / 500f, 1.0f);
		transform.FindChild ("rep_fg").transform.localScale = new Vector3 (0.009f * reputation, 0.1f, 1.0f);
		transform.FindChild ("rep_fg").transform.localPosition = new Vector3 (-0.45f + 0.009f * reputation / 2, -0.55f, -3f);
		transform.FindChild ("rep_fg").renderer.material.color = RepColor ();
		//iTween.ScaleTo (transform.FindChild ("rep_fg").gameObject, new Vector3 (0.009f * reputation, 0.1f, 1.0f), 0.3f);
		//iTween.MoveTo (transform.FindChild ("rep_fg").gameObject, transform.position + new Vector3 (-0.45f + 0.009f * reputation / 2, -0.55f, -3f), 0.3f);
	}

	float Box(float v) {
		if (v < 0) { return 0; }
		if (v > 1) { return 1; }
		return v;
	}

	Color RepColor() {
		return new Color (Box(1.0f - reputation * 0.01f), Box(reputation * 0.01f), Box((reputation - 70) * 0.01f));
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
