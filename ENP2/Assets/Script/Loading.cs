using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TGAME;

public class Loading : MonoBehaviour {

    private Slider m_LoadScrollCtl = null;

    void Awake()
    {
        IGame.Init();
        TAudioMgr.Instance.Play("bgm", true);
    }
    // Use this for initialization
    void Start()
    {
        m_LoadScrollCtl = gameObject.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        m_LoadScrollCtl.value = Mathf.MoveTowards(m_LoadScrollCtl.value, 1.0f, 0.008f);
        if (m_LoadScrollCtl.value >= 1.0f)
        {
            TAutoFade.LoadLevel(1, 1.0f, 1.0f, Color.black);
        }
    }
}
