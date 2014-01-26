using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MidLevelEndConditions : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {
    player = GameObject.Find ("player").GetComponent<GalleryVisitor> ();
    StartCoroutine (CheckForReputation ());

  }

  GalleryVisitor player;

  IEnumerator CheckForReputation ()
  {
    while (true) {
      yield return new WaitForSeconds (5f);
      if (player.reputation <= 3) {
        StartCoroutine (Camera.main.GetComponent<Fader> ().LoadNextLevel ("EndFailure"));
        break;
      }

      if (player.reputation >= 90) {
        StartCoroutine (Camera.main.GetComponent<Fader> ().LoadNextLevel ());
        break;
      }
    }
  }
}
