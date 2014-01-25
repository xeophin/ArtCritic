using UnityEngine;
using System.Collections;

public class FloorArea : MonoBehaviour
{
  public bool OnFloor (int gridX, int gridY, float gridSize)
  {
    return OnFloor (gridX * gridSize, gridY * gridSize);
  }

  public bool OnFloor (float x, float y)
  {
    return renderer.bounds.min.x <= x && renderer.bounds.max.x > x && renderer.bounds.min.y <= y && renderer.bounds.max.y > y;
  }

  public Vector3 GetRandomPositionOnFloor ()
  {
    float x = Random.Range (renderer.bounds.min.x, renderer.bounds.max.x);
    float y = Random.Range (renderer.bounds.min.y, renderer.bounds.max.y);
    return new Vector3 (x, y, 0);
  }
}
