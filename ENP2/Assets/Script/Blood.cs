using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyNow", 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }

    public void DestroyNow()
    {
        //transform.DetachChildren();
        GameObject.Destroy(gameObject);
    }
}
