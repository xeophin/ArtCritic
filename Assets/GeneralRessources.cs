using UnityEngine;
using System.Collections;

public class GeneralRessources : MonoBehaviour
{
  public GUISkin Style;
  public const float BaseScreenWidth = 1280f;
  public const float BaseScreenHeight = 720f;

  public static Vector3 Scale {
    get {
      return new Vector3 (Screen.width / BaseScreenWidth, Screen.height / BaseScreenHeight, 1);
    }
  }
}

