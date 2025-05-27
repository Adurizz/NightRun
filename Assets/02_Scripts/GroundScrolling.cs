using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScrolling : MonoBehaviour
{
    public float speedZ;
    public float limitZ;
    public Vector3 posToReturn;// ���� ������ �� ���ư� ������
    public Transform tr;

    private void Awake()
    {
        // tr = transform;
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        CheckLimit();
        Move();
    }

    void Move()
    {
        transform.Translate(0, 0, -speedZ * Time.deltaTime);
    }

    void CheckLimit()
    {
        if (transform.position.z <= limitZ)
        {
            transform.position = posToReturn;
        }
    }
}
