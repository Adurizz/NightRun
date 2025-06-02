using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeSystem : MonoBehaviour
{
    public float curTime;
    public float coolTime = 2f;
    public bool isClicked = false;
    public Image gauge;
    public TextMeshProUGUI text;

    private void Update()
    {
        if (!isClicked)
            return;

        curTime += Time.deltaTime;
        gauge.fillAmount = curTime / coolTime;
        text.text = ((int)(curTime / coolTime * 100)).ToString() + "%";
        if (curTime > coolTime)
        {
            curTime = 0;
            isClicked = false;
        }
    }

    public void Click()
    {
        isClicked = true;
    }
}
