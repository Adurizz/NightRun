using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Color originalColor = Color.black;
    public Color targetColor = Color.red;
    public int updateTime = 1000;
    public float updateInterval = 0.01f;

    public Text title;

    public Color32 myColor;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorBlinkEffect());
    }

    IEnumerator ColorBlinkEffect()
    {
        float colorDiffR = targetColor.r - originalColor.r;
        float updateAmount = colorDiffR / updateTime;

        int direction = 1;
        while (true)
        {
            Color curColor = title.color;
            Color tempColor = new Color(curColor.r + (updateAmount * direction), 0, 0);
            title.color = tempColor;
            if (tempColor.r >= 1f || tempColor.r <= 0)
                direction *= -1;
            yield return new WaitForSeconds(updateInterval);
        }

    }

    public void MoveToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ToggleUIActiveState(GameObject go)
    {
        go.SetActive(!go.activeSelf);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
