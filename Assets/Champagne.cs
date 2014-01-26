using System;
using UnityEngine;

public class Champagne : MonoBehaviour
{
	public AudioClip drink;

  public float drunkenness = 0;
  public FloorArea floor;

  static void ChampagneForEveryone ()
  {
    
  }

  #region GUI

  Matrix4x4 oldMatrix;
  Rect buttonPosition = new Rect (20f, 680f, 20f, 20f);

  void OnGUI ()
  {
    oldMatrix = GUI.matrix;
    GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, GeneralRessources.Scale);

    if (GUI.Button (buttonPosition, "Drink up!")) {
      drunkenness += 0.1f;

      // Kill all challenges
      foreach (Challenge ch in FindObjectsOfType<Challenge> ()) {
        ArtObject ao = GalleryVisitor.GetClosestArtwork (transform.position);
        if (ch.victim == gameObject.GetComponent<GalleryVisitor> () && ch.topic == ao) {
          Destroy (ch.gameObject);
        }
      }

      // Go to another place
      Vector3 goTo = floor.GetRandomPositionOnFloor ();
      iTween.MoveTo (this.gameObject, goTo, 2f);
		if (drink != null) { GetComponent<AudioSource> ().PlayOneShot (drink); }
    }

    GUI.matrix = oldMatrix;
  }

  #endregion

}

