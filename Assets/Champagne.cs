using System;
using UnityEngine;

public class Champagne : MonoBehaviour
{
  public float drunkenness = 0;

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

    if (GUI.Button (buttonPosition, "Drink up")) {
      drunkenness += 0.1f;

      // Go to another place
    }

    GUI.matrix = oldMatrix;
  }

  #endregion

}

