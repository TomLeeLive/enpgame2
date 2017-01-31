using UnityEngine;
using System; // serialized
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TGAME
{
    static class IGame
    {
        static public CUserPublishInfo g_UserData = null;
        static public CGameOption g_GameOption = null;
        static public int g_iScore = 0;
        static IGame()
        {
            g_UserData = new CUserPublishInfo();
            g_GameOption = new CGameOption();

            //PlayerPrefs.DeleteAll();
            if (PlayerPrefs.HasKey("g_iUserLevel"))
                g_UserData.g_iUserLevel = PlayerPrefs.GetInt("g_iUserLevel", g_UserData.g_iUserLevel);
            if (PlayerPrefs.HasKey("g_iScore"))
                g_UserData.g_iUserScore = PlayerPrefs.GetInt("g_iScore", g_UserData.g_iUserScore);
            // Game Option
            if (PlayerPrefs.HasKey("m_bgMusic"))
                g_GameOption.m_bgMusic = (PlayerPrefs.GetInt("m_bgMusic") == 0) ? true : false;
            if (PlayerPrefs.HasKey("m_effectSound"))
                g_GameOption.m_effectSound = (PlayerPrefs.GetInt("m_effectSound") == 0) ? true : false;
            if (PlayerPrefs.HasKey("m_MessageNoti"))
                g_GameOption.m_MessageNoti = (PlayerPrefs.GetInt("m_MessageNoti") == 0) ? true : false;      

            Load();
        }
        static public void Init() {  }
        static public void Save()
        {
            g_UserData.g_iUserScore += IGame.g_iScore;
            if (UpdateDB(true) < 0)
            {
                Debug.Log("심각한 문제가 발생!!!!");
            }
            IGame.g_iScore = 0;
        }
        static public int UpdateDB(bool bGameFinish = false)
        {
            if (bGameFinish)
            {
                PlayerPrefs.SetInt("g_iUserLevel", g_UserData.g_iUserLevel);
                PlayerPrefs.SetInt("g_iScore", g_UserData.g_iUserScore);
            }
            SaveItem();
            return 1;
        }
        static public void SaveItem()
        {       
            // CGameOption
            PlayerPrefs.SetInt("m_bgMusic", g_GameOption.m_bgMusic ? 0 : 1);
            PlayerPrefs.SetInt("m_effectSound", g_GameOption.m_effectSound ? 0 : 1);
            PlayerPrefs.SetInt("m_MessageNoti", g_GameOption.m_MessageNoti ? 0 : 1);
            PlayerPrefs.Save();
        }

        static public void Load()
        {
            TPrefabMgr.Load("Prefabs", null);
            TAudioMgr.Instance.Load();
        }
    }
}