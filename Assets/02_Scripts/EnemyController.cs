using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }
}
