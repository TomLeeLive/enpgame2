using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyNow", 1.0f);
	}
	public void DestroyNow()
    {
        transform.DetachChildren();
        DestroyObject(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
