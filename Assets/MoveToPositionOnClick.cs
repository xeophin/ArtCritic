using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEditor;

/// <summary>
/// Makes the game object move to the position clicked.
/// </summary>
public class MoveToPositionOnClick : MonoBehaviour
{
  Vector3 target;
  // Update is called once per frame
  void Update ()
  {
    if (Input.GetMouseButtonUp (0)) {
      target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
      target = new Vector3 (target.x, target.y, 0);
      iTween.MoveTo (this.gameObject, target, 1f);
    }
  }
}


