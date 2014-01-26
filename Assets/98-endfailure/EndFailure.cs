using UnityEngine;
using System.Collections;

/// <summary>
/// Shows the splashscreen.
/// </summary>
public class EndFailure : MonoBehaviour
{
  GameObject fade;
  // Use this for initialization
  void Start ()
  {
    style = Camera.main.GetComponent<GeneralRessources> ().Style;
    fade = iTween.CameraFadeAdd ();
    iTween.CameraFadeFrom (1f, 3f);

  }

  GUISkin style;
  Rect position = new Rect (1000f, 640f, 260f, 60f);
  Vector3 scale;
  Matrix4x4 oldScale;

  void OnGUI ()
  {
    oldScale = GUI.matrix;
    GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, GeneralRessources.Scale);
    GUI.skin = style;
    if (GUI.Button (position, "Again, again!")) {
      StartCoroutine (RestartGame ());
    }

    GUI.matrix = oldScale;
  }

  IEnumerator RestartGame ()
  {
    iTween.CameraFadeAdd ();
    iTween.CameraFadeTo (1f, 3f);
    yield return new WaitForSeconds (3f);
    Application.LoadLevel (1);
  }
}
