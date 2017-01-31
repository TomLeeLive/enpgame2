using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1S : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        TAutoFade.LoadLevel(3, 1.0f, 1.0f, Color.black);

        //SceneManager.LoadScene("Stage1S");
    }
}
