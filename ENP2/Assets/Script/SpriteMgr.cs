using UnityEngine;
using System.Collections;

// c# 으로 할경우 [System.Serializable] 을 해줘야 별도의 작성된
// 클래스가 MonoBehaviour를 타고 인스펙터에 표시 된다
[System.Serializable]
public class ScriptMgr
{
    public Texture2D spriteTexture; // 교체 텍스터
    public int framePerSec; // 전체 프레임 개수
    public int gridX; //  가로 프레임 개수
    public int gridY; //  세로 프레임 개수
    private float timePercent; // 프레임 교체 시간
    private float nextTime; // 다음 프레임 교체 시간
    private float perGridX; // 가로 프레임 교체 오프셋
    private float perGridY; //  세로 프레임 교체 오프셋
    private int curFrame; // 현재 프레임 인덱스

    public void init()
    {
        timePercent = 1.0f / framePerSec;
        nextTime = timePercent;
        perGridX = 1.0f / gridX;
        perGridY = 1.0f / gridY;
        curFrame = 1;
    }

    public void updateAnimation(int direction, Material material)
    {
        material.mainTexture = spriteTexture;
        if (Time.time > nextTime)
        {
            nextTime = Time.time + timePercent;
            curFrame++;
            if (curFrame > framePerSec)
            {
                curFrame = 1;
            }
        }
        material.mainTextureScale = new Vector2(direction * perGridX, perGridY);

        float col = 0;
        int in_col = 0;

        if (gridY > 1)
        {
            // 세로 프레임 
            col = Mathf.Ceil(curFrame / gridX);
            in_col = System.Convert.ToInt16(col);
        }
        if (direction == 1)
        {
            material.mainTextureOffset = new Vector2(((curFrame) % gridX) * perGridX, in_col * perGridY);
        }
        else
        {
            material.mainTextureOffset = new Vector2(((gridX + (curFrame) % gridX)) * perGridX, in_col * perGridY);
        }
    }

    public void m_JumpClip(int direction, Material material)
    {
        material.mainTexture = spriteTexture;
        //이동 방향에 따라 그림을 반전을 시켜줘야 하는데
        // X축 스케일을 -로 해버리면 보여주는 그림이 반대가 되게 해준다.
        material.mainTextureScale = new Vector2(direction * 1, 1);
        //Texture를 얼마나 이동시켜 찍을지 결정함.
        material.mainTextureOffset = new Vector2(direction * 1, 1);
    }
    public void resetFrame()
    {
        curFrame = 1;
    }
}
