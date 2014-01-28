using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;

/// <summary>
///  A statement about an art object.
/// </summary>
public class Statement : MonoBehaviour
{
  public float lifespan = 3.5f;
  public Vector3 offset = new Vector3 (0, 0, 0);
  public ArtProperties property;
  public string text;
  public GalleryVisitor emitter;
  public ArtObject topic;
  public bool opinion;
  // -1 to +1
  public List<GalleryVisitor> hasReacted = new List<GalleryVisitor> ();
  public float age;
  public bool textDisplayed;
  public bool repeat;
  public Font font;
  TextMesh textmesh;

  public void Init (ArtProperties property, GalleryVisitor emitter, ArtObject topic, bool opinion)
  {
    this.property = property;
    this.emitter = emitter;
    this.topic = topic;
    this.opinion = opinion;
    transform.position = emitter.transform.position + offset;
    text = "Hmm...";
    textmesh = this.gameObject.GetComponentInChildren<TextMesh> ();
    textmesh.text = "Hmm...";
    transform.localScale = new Vector3 (0.0f, 0.0f, 1.0f);

    repeat = topic.lastPropertyStated == property;
    topic.lastPropertyStated = property;

    foreach (Challenge ch in FindObjectsOfType<Challenge> ()) {
      if (ch.victim == emitter && ch.topic == topic) {
        Destroy (ch.gameObject);
      }
    }

    if (opinion) {
      emitter.GetComponent<Speaker> ().playGood ();
    } else {
      emitter.GetComponent<Speaker> ().playBad ();
    }

    textmesh.gameObject.renderer.sortingLayerID = 3;
  }

  void Start ()
  {
    Destroy (this.gameObject, lifespan);
    textmesh = this.gameObject.GetComponentInChildren<TextMesh> ();
  }
  // Update is called once per frame
  void Update ()
  {
    age += Time.deltaTime;
    if (!textDisplayed) {
      Listeners ls = GetComponent<Listeners> ();
      if (ls.found) {
        GalleryVisitor pgv = GameObject.FindWithTag ("Player").GetComponent<GalleryVisitor> ();
        if (ls.listeners.Contains (pgv)) {
          text = property.ToString () + "!";
          textmesh.text = text;
          transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
          iTween.PunchScale (this.gameObject, new Vector3 (1.1f, 1.1f, 1.0f), 0.5f);
        } else {
          text = "...";
          textmesh.text = "...";
          transform.localScale = new Vector3 (0.67f, 0.67f, 1.0f);
        }
        textDisplayed = true;
      }
    }
  }
}
