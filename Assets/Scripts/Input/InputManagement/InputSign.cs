using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputManagement
{ 
    public class InputSign : MonoBehaviour
    {
        public float downShift = 30f;
        public float leftShift = 30f;
        public int age = 0;

        public void DownShift()
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - downShift);
            age++;
        }
        public void LeftShift(int scale)
        {
            transform.position = new Vector2(transform.position.x - leftShift * scale, transform.position.y);
        }
    }
}
