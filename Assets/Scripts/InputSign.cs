using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSign : MonoBehaviour
{
    public float downShift = 30f;
    public float leftShift = 30f;

    public void DownShift()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - downShift);
    }
    public void LeftShift(int scale)
    {
        transform.position = new Vector2(transform.position.x - leftShift * scale, transform.position.y);
    }
}
