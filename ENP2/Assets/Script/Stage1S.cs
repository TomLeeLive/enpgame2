using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1S : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKey(KeyCode.Space))
        {
            //Stage1으로
            TAutoFade.LoadLevel(3, 1.0f, 1.0f, Color.black);
        }

        if (Input.GetKey(KeyCode.Return))
        {
            //메뉴로
            TAutoFade.LoadLevel(1, 1.0f, 1.0f, Color.black);
        }
    }

    public void Clicked()
    {
        TAutoFade.LoadLevel(3, 1.0f, 1.0f, Color.black);

        //SceneManager.LoadScene("Stage1S");
    }
}
