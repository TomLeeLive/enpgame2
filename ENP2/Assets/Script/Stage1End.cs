using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1End : MonoBehaviour {

    public Transform Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(Player.transform.position, transform.position);

        if(distance < 20.0f)
        {
            TAutoFade.LoadLevel(5, 1.0f, 1.0f, Color.black);
        }
    }
}
