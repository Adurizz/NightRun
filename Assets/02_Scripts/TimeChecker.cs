using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI maxTimeText;
    public float curTime;
    public float maxTime;

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        timeText.text = ((int)curTime).ToString() + "s";
    }

    public void SetMaxTime()
    {
        if (curTime > maxTime)
        {
            maxTime = curTime;
            maxTimeText.text = ((int)maxTime).ToString() + "s";
        }
    }
}
