using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // FPS
    public TMPro.TextMeshProUGUI FPSText;
    int m_frameCounter = 0;
    float m_timeCounter = 0.0f;
    float m_lastFramerate = 0.0f;
    public float m_refreshTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        UpdateFPS();
    }

    private void UpdateFPS()
    {
        if (m_timeCounter < m_refreshTime)
        {
            m_timeCounter += Time.deltaTime;
            m_frameCounter++;
        }
        else
        {
            //This code will break if you set your m_refreshTime to 0, which makes no sense.
            m_lastFramerate = (float)m_frameCounter / m_timeCounter;
            m_frameCounter = 0;
            m_timeCounter = 0.0f;
        }

        string fps_number = m_lastFramerate.ToString();
        string[] splitArray = fps_number.Split(".");
        FPSText.text = splitArray[0];
    }
}
