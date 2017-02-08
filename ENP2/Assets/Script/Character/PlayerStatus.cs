using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {

    public Slider m_SliderHP = null;
    public Slider m_SliderBullet = null;
    public FirstPersonController fpc = null;

    // Use this for initialization
    void Start () {
        //m_SliderHP = gameObject.GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update () {
        m_SliderHP.value = (float)fpc.m_iHP / 100.0f; //Mathf.MoveTowards(m_SliderHP.value, 1.0f, 0.008f);
        m_SliderBullet.value = (float)fpc.m_iBullet / 100.0f; //Mathf.MoveTowards(m_SliderHP.value, 1.0f, 0.008f);
        if (m_SliderHP.value <= 0.0f)
        {
            //게임오버 Scene으로 전환.

           // TAutoFade.LoadLevel(1, 1.0f, 1.0f, Color.black);
        }
    }
}
