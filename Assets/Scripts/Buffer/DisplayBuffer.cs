using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Buffer
{
    public class DisplayBuffer : MonoBehaviour
    {
        private List<List<BufferItem>> buffer;
        public void Start()
        {
            buffer = FindObjectOfType<InputBufferSystem>().buffer;
        }
        public void Update()
        {
            Text txt = GetComponent<Text>();
            string output = "Buffer:\n";
            for (int i = 0; i < buffer.Count; i++)
            {
                string frameOutput = "";
                for (int j = 0; j < buffer[i].Count; j++)
                {
                    if (j == 0)
                    {
                        frameOutput = string.Format("({0}, ", buffer[i][j].inputName);
                        if (buffer[i][j].used)
                        {
                            frameOutput = string.Format("{0}*", frameOutput);
                        }
                    }
                    else if (j == 1)
                    {
                        frameOutput = string.Format("{0}{1}) ", frameOutput, buffer[i][j].inputName);
                        if (buffer[i][j].used)
                        {
                            frameOutput = string.Format("{0}*", frameOutput);
                        }
                    }
                    else
                    {
                        frameOutput = string.Format("{0} {1}", frameOutput, buffer[i][j].inputName);
                        if (buffer[i][j].used)
                        {
                            frameOutput = string.Format("{0}*", frameOutput);
                        }
                    }
                }
                output = string.Format("{0}{1}: {2}\n", output, i, frameOutput);
            }
            txt.text = output;
        }
    }
}