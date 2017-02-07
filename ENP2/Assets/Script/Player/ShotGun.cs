using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TGAME;

public class ShotGun : MonoBehaviour {

    public CharacterController m_Ctl;
    private Animation m_Animation;
    private AnimationClip m_Shoot;

    void Awake()
    {
        m_Ctl = GetComponent<CharacterController>();
        m_Animation = GetComponent<Animation>();
        m_Shoot = m_Animation.GetClip("shoot");

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if(m_Animation.isPlaying == false)
            {
                m_Animation.CrossFade(m_Shoot.name, 0.1f);
                TAudioMgr.Instance.PlayEffect("shot1");
            }       
        }
    }
}
