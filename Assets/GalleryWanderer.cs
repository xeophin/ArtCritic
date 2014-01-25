using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GalleryWanderer : MonoBehaviour {
	public float maxInitialWait = 5;
	public float moveTime = 3;
	public float minObserveTime = 4; public float maxObserveTime = 9;

	public int gridTargetX;
	public int gridTargetY;
	public ArtObject observing;
	public float timeUntilMove;
	public float timeUntilNotMoving;
	public List<ArtObject> visited = new List<ArtObject>();

	// Use this for initialization
	void Start () {
		WaitUntilMove (Random.Range (0, maxInitialWait));
	}

	public bool IsMoving() {
		return timeUntilNotMoving > 0;
	}

	// Update is called once per frame
	void Update () {
		timeUntilMove -= Time.deltaTime;
		timeUntilNotMoving -= Time.deltaTime;
		if (CanMove ()) {
			ArtObject target = FindNextTarget();
			if (target != null) {
				int[] freeTile = FindFreeAdjacentTile(target.GetComponent<OnGrid>());
				if (freeTile != null) {
					//Debug.Log("Moving to " + freeTile[0] + " / " + freeTile[1] + " = " + GetComponent<OnGrid>().V3Position(gridTargetX, gridTargetY));
					gridTargetX = freeTile[0];
					gridTargetY = freeTile[1];
					observing = target;
					if (!visited.Contains(target)) {
						visited.Add (target);
					}
					iTween.MoveTo(this.gameObject, GetComponent<OnGrid>().V3Position(gridTargetX, gridTargetY), moveTime);
					timeUntilNotMoving = moveTime;
					WaitUntilMove(moveTime + Random.Range(minObserveTime, maxObserveTime));
				}
			}
		}
	}

	int[] FindFreeAdjacentTile(OnGrid target) {
		int tx = target.GridX ();
		int ty = target.GridY ();
		OnGrid[] gridObjects = FindObjectsOfType<OnGrid> ();
		GalleryWanderer[] wanderers = FindObjectsOfType<GalleryWanderer> ();
		for (int dy = -1; dy < 2; dy++) {
			for (int dx = -1; dx < 2; dx++) {
				if (IsTileFree(tx + dx, ty + dy, gridObjects, wanderers)) {
					return new int[] { tx + dx, ty + dy };
				}
			}
		}

		return null;
	}

	bool IsHeadingFor(int gx, int gy) {
		return gridTargetX == gx && gridTargetY == gy;
	}

	bool IsTileFree(int gx, int gy, OnGrid[] gridObjects, GalleryWanderer[] wanderers) {
		foreach (OnGrid og in gridObjects) {
			if (og.gameObject != gameObject && og.At (gx, gy)) {
				return false;
			}
		}
		foreach (GalleryWanderer gw in wanderers) {
			if (gw != this && gw.IsHeadingFor(gx, gy)) {
				return false;
			}
		}
		return true;
	}
	
	ArtObject FindNextTarget() {
		ArtObject[] objs = FindObjectsOfType<ArtObject> ();
		List<ArtObject> candidates = new List<ArtObject> ();
		for (int i = 0; i < objs.Length; i++) {
			ArtObject o = objs[i];
			if (!visited.Contains(o)) {
				candidates.Add (o);
			}
		}
		if (candidates.Count > 0) {
			return candidates[Random.Range(0, candidates.Count)];
		} else {
			return objs[Random.Range(0, objs.Length)];
		}
	}

	bool CanMove() {
		return timeUntilMove <= 0;
	}

	public void WaitUntilMove(float time) {
		if (time > timeUntilMove) { timeUntilMove = time; }
	}
}
