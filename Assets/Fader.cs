using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fader : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {
    iTween.CameraFadeAdd ();
    iTween.CameraFadeFrom (1f, 3f);
  }

  IEnumerator LoadNextLevel ()
  {
    iTween.CameraFadeTo (0f, 3f);
    yield return new WaitForSeconds (3f);
    Application.LoadLevel (Application.loadedLevel + 1);
  }
}
