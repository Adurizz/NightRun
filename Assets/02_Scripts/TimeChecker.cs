using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeChecker : MonoBehaviour
{
    public TextMesh timeText;
    public float curTime;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        timeText.text = "TIME: " + ((int)curTime).ToString();
    }
}
