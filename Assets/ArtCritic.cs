using UnityEngine;
using System.Collections;

public class ArtCritic : MonoBehaviour
{
  Transform art;
  public GameObject obj;
  // Use this for initialization
  void Start ()
  {
    art = GameObject.Find ("art").transform;
  }
  // Update is called once per frame
  void Update ()
  {
    //Instantiate (obj, Vector3.zero, Quaternion.identity);
  }
}
