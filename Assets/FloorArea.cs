using UnityEngine;
using System.Collections;

public class FloorArea : MonoBehaviour {
	public bool OnFloor(int gridX, int gridY, float gridSize) {
		return OnFloor (gridX * gridSize, gridY * gridSize);
	}

	public bool OnFloor(float x, float y) {
		return renderer.bounds.min.x <= x && renderer.bounds.max.x > x && renderer.bounds.min.y <= y && renderer.bounds.max.y > y;
	}
}
