using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyButtonCallback : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClickMyButton()
    {
        Debug.Log("버튼 클릭");
    }
}
