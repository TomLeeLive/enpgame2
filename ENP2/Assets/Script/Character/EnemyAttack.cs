using UnityEngine;
using System.Collections;

static class Constants
{
    public const float fShotTime = 10.0f;
}

public partial class EnemyMgr : MonoBehaviour
{
    // 공격 필요 여부를 판단한다.
    public bool Shoot(Vector3 _direction)
    {
        RaycastHit hit;
        // 유저가 사정 거리 안에 있는지 판단
        if (Vector3.Distance(transform.position, m_Player.position) <= (m_fPlayerRange + m_fShotRange))
        {
            // 장애물 여부를 판단한다.



#if OBSTACLE_CHECK
            if (Physics.Raycast(transform.position, _direction, out hit, m_fShotRange))
            {
                if (hit.transform.tag != "Wall")
                {
                    m_bAiming = true;
                }
#else
            m_bAiming = true;
#endif

            return true;
        }
        m_bAiming = false;
        return false;
    }
    public void AttackMove(Vector3 vRocketDirection)
    {
        Vector3 v3_movement;
        m_vMoveDirection = Vector3.MoveTowards(m_vMoveDirection, vRocketDirection, 0.1f);
        m_vMoveDirection = m_vMoveDirection.normalized;

        if (IsGrounded())
        {
            m_fVerticalSpeed = 0.0f;
            m_bJumping = false;
        }
        else
        { 
            // 중력
            m_fVerticalSpeed -= m_fGravity * Time.deltaTime;
        }

        v3_movement = new Vector3(0, m_fVerticalSpeed, 0);
        v3_movement *= Time.deltaTime;

        if (!m_bPrepare)
        {
            m_bShot = false;
            StartCoroutine("WaitForPrepare");
        }
        else
        {
            if (vRocketDirection == m_vMoveDirection)
            {
                if (!m_bShot)
                {
                    m_bShot = true;
                    StartCoroutine("WaitForShot");
                }
            }
        }
        m_CollisionFlags = m_Ctl.Move(new Vector3(0, v3_movement.y, 0));
        transform.rotation = Quaternion.LookRotation(m_vMoveDirection);
    }
    private IEnumerator WaitForShot()
    {
        m_Animation[m_ShotAnimation.name].speed = m_fShotSpeed;
        m_Animation[m_ShotAnimation.name].wrapMode = WrapMode.ClampForever;
        m_Animation.PlayQueued(m_ShotAnimation.name, QueueMode.PlayNow);
        BroadcastMessage("Fire", m_ShotAnimation.length);

        yield return new WaitForSeconds(m_ShotAnimation.length * Constants.fShotTime);
        m_bShot = false;
    }
    private IEnumerator WaitForPrepare()
    {
        m_Animation[m_ShotAnimation.name].speed = m_fShotSpeed;
        m_Animation[m_ShotAnimation.name].wrapMode = WrapMode.ClampForever;
        m_Animation.CrossFade(m_ShotAnimation.name, 0.1f);

        yield return new WaitForSeconds(m_ShotAnimation.length * Constants.fShotTime);
        m_bPrepare = true;
    }
}