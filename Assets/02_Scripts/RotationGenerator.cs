using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGenerator : MonoBehaviour
{
    public float rotateAmount;
    private void Update()
    {
        transform.Rotate(0, rotateAmount * Time.deltaTime, 0, Space.World);
    }
}
