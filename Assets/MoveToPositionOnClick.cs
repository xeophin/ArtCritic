using UnityEngine;

/// <summary>
/// Makes the game object move to the position clicked.
/// </summary>
public class MoveToPositionOnClick : MonoBehaviour
{
  public GameObject floor;
  Vector3 target;
  // Update is called once per frame
  void Update ()
  {
    if (Input.GetMouseButtonUp (0)) {
      foreach (Statement st in FindObjectsOfType<Statement> ()) {
        if (st.emitter == GetComponent<GalleryVisitor> ()) {
          return;
        }
      }
      target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
      target = new Vector3 (target.x, target.y, 0);
		if (GetComponent<Champagne> ().doNonsense()) {
			GetComponent<ParticleSystem> ().Play ();
			iTween.MoveTo (this.gameObject, floor.GetComponent<FloorArea> ().GetRandomPositionOnFloor (), 1f);
		} else { 
	      if (floor != null && floor.GetComponent<FloorArea> ().OnFloor (target.x, target.y)) {
	        iTween.MoveTo (this.gameObject, target, 1f);
	      } else {
	        //iTween.ShakePosition (this.gameObject, new Vector3 (0.2f, 0, 0), 0.5f);
	      }
		}
    }
  }
}


