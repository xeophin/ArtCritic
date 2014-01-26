using UnityEngine;
using System.Collections;
using System.Runtime.ConstrainedExecution;

public class Tutorial : MonoBehaviour
{
  // Use this for initialization
  void Start ()
  {
    visitor = FindObjectOfType<Opinionated> ();
    player = FindObjectOfType<InventoryOfStatements> ();
    StartCoroutine (ResetWatchedObject ());
    StartCoroutine (WatchForElementsInStatements ());
    style = Camera.main.GetComponent<GeneralRessources> ().Style;
  }

  Opinionated visitor;
  InventoryOfStatements player;
  Rect pos = new Rect (20f, 20f, 800f, 150f);
  GUISkin style;

  void OnGUI ()
  {
    GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, GeneralRessources.Scale);
    GUI.skin = style;
    GUI.Label (pos, "This gentleman seems knowledgable. Get close to him by clicking beside the artwork and observe to learn.");
  }

  IEnumerator WatchForElementsInStatements ()
  {
    while (true) {
      yield return new WaitForSeconds (8f);
      if (player.inventory.Count >= 2) {
        StartCoroutine (Camera.main.GetComponent<Fader> ().LoadNextLevel ());
        break;
      }
    }
  }

  IEnumerator ResetWatchedObject ()
  {
    while (true) {
      yield return new WaitForSeconds (8f);
      visitor.observed = null;
    }
  }
}
