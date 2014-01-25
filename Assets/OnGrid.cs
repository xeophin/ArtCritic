using UnityEngine;
using System.Collections;

public class OnGrid : MonoBehaviour {
	public float gridSize = 1;

	void Start() {
		// Snap to.
		transform.position = V3Position (GridX (), GridY ());
	}

	public bool At(int gridX, int gridY) {
		return GridX () == gridX && GridY () == gridY; 
	}

	public int GridX() {
		return Mathf.FloorToInt(transform.position.x / gridSize);
	}

	public int GridY() {
		return Mathf.FloorToInt(transform.position.y / gridSize);
	}

	public Vector2 Position(int x, int y) {
		return new Vector2(x * gridSize, y * gridSize);
	}

	public Vector2 V3Position(int x, int y) {
		return new Vector3(x * gridSize, y * gridSize, transform.position.z);
	}
}
