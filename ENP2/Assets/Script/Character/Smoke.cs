using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

    public float timeOut = 0.5f;
	// Use this for initialization
	void Start () {
        Invoke("KillObject", timeOut);
	}
    private void KillObject()
    {
       Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
