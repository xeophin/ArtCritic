using UnityEngine;
using System.Collections;

/// <summary>
/// Shows the splashscreen.
/// </summary>
public class SplashScreen : MonoBehaviour
{
  GameObject fade;
  // Use this for initialization
  IEnumerator Start ()
  {
    fade = iTween.CameraFadeAdd ();
    iTween.CameraFadeFrom (1f, 3f);
    yield return new WaitForSeconds (10f);
    iTween.CameraFadeTo (1f, 3f);
    yield return new WaitForSeconds (3f);
    Application.LoadLevel (1);
  }
}
