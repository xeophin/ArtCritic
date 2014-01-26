using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
  // Use this for initialization
  IEnumerator Start ()
  {
    iTween.CameraFadeAdd ();
    iTween.CameraFadeFrom (1f, 3f);
    yield return new WaitForSeconds (4f);
    iTween.CameraFadeDestroy ();
  }

  public IEnumerator LoadNextLevel ()
  {
    Debug.Log ("Load next level");
    iTween.CameraFadeAdd ();
    iTween.CameraFadeTo (0f, 3f);
    yield return new WaitForSeconds (4f);
    Application.LoadLevel (Application.loadedLevel + 1);
  }
}
