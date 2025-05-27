using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public Renderer rend;

    void Update()
    {
        float offset = Time.time * -scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
