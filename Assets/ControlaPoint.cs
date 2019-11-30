using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaPoint : MonoBehaviour
{
    // Interpolate light color between two colors back and forth
    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.yellow;
    public Transform target1;
    public float control1;

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        control1 = target1.position.y;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
        if (control1 <= target1.position.y)
        {
            lt.color = Color.green;
        }
    }
}