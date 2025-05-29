using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform playerTransform;
    public int limitX;

    bool isLeft;
    bool isRight;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnClickMoveBtn(bool isLeft)
    {
        Move();
    }

    private void Move()
    {
        if (isLeft)
        {
            if (playerTransform.position.x <= -limitX)
                return;
            Debug.Log("L �̵�");
            playerTransform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (isRight)
        {
            if (playerTransform.position.x >= limitX)
                return;
            Debug.Log("R �̵�");
            playerTransform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    public void RevealMessage(string message)
    {
        Debug.Log(message);
    }

    public void PressLBtn()
    {
        Debug.Log("L��ư ����");
        isLeft = true;
    }

    public void ReleaseLBtn()
    {
        Debug.Log("L��ư ��");
        isLeft = false;
    }

    public void PressRBtn()
    {
        Debug.Log("L��ư ����");
        isRight = true;
    }

    public void ReleaseRBtn()
    {
        Debug.Log("L��ư ��");
        isRight = false;
    }
}
