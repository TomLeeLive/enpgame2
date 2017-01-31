using UnityEngine;
using System;
using System.Collections;

public class CUserPublishInfo
{
    public Guid   m_guid;//플레이어 캐릭터의 guid
    public String m_name;//플레이어 캐릭터의 이름
    public int g_iUserLevel;       // 유져 레벨   
    public int g_iUserScore;           // 점수

    public CUserPublishInfo()
    {
        m_name = "none";
        g_iUserLevel = 0;
        g_iUserScore = 0;
    }
}

public class CGameRoomParameter
{
    public Guid m_guid;
    public String m_name;
    public int m_type;
    public Guid m_masterHeroGuid;
}

public class CGameShopParameter
{
    public Guid m_guid;
    public String m_name;
    public int m_type;
    public int m_price;
}

public class CGameOption
{
    public bool m_bgMusic = true;
    public bool m_effectSound = true;
    public bool m_MessageNoti = true;
}

enum TGameFinishState { NEXT_GAME_PLAY = 0, USER_LEVEL_UP, USER_ROOM_MAX_LEVEL, GAME_REPLAY }