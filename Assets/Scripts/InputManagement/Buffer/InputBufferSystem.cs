using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

namespace InputManagement.Buffer
{
    public class InputBufferSystem : MonoBehaviour
    {
        Inputs inputs;
        [SerializeField] [Range(3,30)] int maxBufferSize = 10;
        public List<List<BufferItem>> buffer = new List<List<BufferItem>>();
        private List<string> watchlist = new List<string>();

        private string prepath;
        private string path;
        FileStream fs;
        StreamReader sr = null;
        StreamWriter sw = null;
        bool scriptPresent = false;
        bool EOF = false;
        // UNIQUE ATTRIBUTES
        private float _horizontal, _vertical, _jump, _dash, _lightAttack, _mediumAttack, _heavyAttack;

        public void Awake()
        {
            CreateText();

            inputs = new Inputs();

            inputs.InputBufferActions.Horizontal.performed += context => _horizontal = context.ReadValue<float>();
            inputs.InputBufferActions.Horizontal.canceled += context => _horizontal = 0f;
            inputs.InputBufferActions.Vertical.performed += context => _vertical = context.ReadValue<float>();
            inputs.InputBufferActions.Vertical.canceled += context => _vertical = 0f;
            inputs.InputBufferActions.Jump.performed += context => _jump = context.ReadValue<float>();
            inputs.InputBufferActions.Jump.canceled += context => _jump = 0f;
            inputs.InputBufferActions.Dash.performed += context => _dash = context.ReadValue<float>();
            inputs.InputBufferActions.Dash.canceled += context => _dash = 0f;
            inputs.InputBufferActions.LightAttack.performed += context => _lightAttack = context.ReadValue<float>();
            inputs.InputBufferActions.LightAttack.canceled += context => _lightAttack = 0f;
            inputs.InputBufferActions.MediumAttack.performed += context => _mediumAttack = context.ReadValue<float>();
            inputs.InputBufferActions.MediumAttack.canceled += context => _mediumAttack = 0f;
            inputs.InputBufferActions.HeavyAttack.performed += context => _heavyAttack = context.ReadValue<float>();
            inputs.InputBufferActions.HeavyAttack.canceled += context => _heavyAttack = 0f;
        }
        public void Update()
        {
            ManageBuffer();
        }
        private void ManageBuffer()
        {
            if (EOF) return; // For reading purposes
            while (buffer.Count >= maxBufferSize) buffer.RemoveAt(0); // Cull buffer

            List<BufferItem> frameBuffer = new List<BufferItem>();
            string[] curReadInputs = null;
            if (scriptPresent)
            {
                string curLine = sr.ReadLine();
                if (curLine == "END")
                {
                    EOF = true;
                    return;
                }
                curReadInputs = curLine.Split(' ');

            }
            UpdateMovement(frameBuffer, curReadInputs);
            UpdateJump(frameBuffer, curReadInputs);
            UpdateDash(frameBuffer, curReadInputs);
            UpdateLightAttack(frameBuffer, curReadInputs);
            UpdateMediumAttack(frameBuffer, curReadInputs);
            UpdateHeavyAttack(frameBuffer, curReadInputs);

            buffer.Add(frameBuffer);
            for (int i = 0; i < watchlist.Count; i++)
            {
                bool found = false;
                for (int j = 0; j < frameBuffer.Count; j++)
                {
                    if (watchlist[i] == frameBuffer[j].inputName)
                        found = true;
                }
                if (!found)
                    watchlist.Remove(watchlist[i]);
            }
            if(!scriptPresent)
            {
                string textToAdd = "";
                foreach (BufferItem item in frameBuffer)
                {
                    string content = item.inputName + " ";
                    textToAdd += content;
                }
                sw.WriteLine(textToAdd);
            }
        }
        public List<string> GetUnusedOptions()
        {
            List<string> options = new List<string>();
            for (int i = 0; i < buffer.Count; i++)
            {
                for (int j = 2; j < buffer[i].Count; j++) // Currently we aren't buffering direction input, so we start at 2
                {
                    BufferItem curItem = buffer[i][j];
                    if (!curItem.used && !options.Contains(curItem.inputName)) //If the frame buffer contains an element not in the current avaialble options, add it to options if it wasn't been used
                    {
                        options.Add(curItem.inputName);
                    }
                }
            }
            return options;
        }
        public void UseOption(string inputName)
        {
            bool foundFlag = false;
            int sequentialTracker = 0;
            //Find the first instance where the input occurs in the buffer, but is not yet used
            for (int i = 0; i < buffer.Count; i++)
            {
                for (int j = 0; j < buffer[i].Count; j++)
                {
                    BufferItem curItem = buffer[i][j];
                    if (!foundFlag)
                    {
                        if (!curItem.used && curItem.inputName == inputName) //If the frame buffer contains an element not in the current avaialble options, add it to options if it wasn't been used
                        {
                            curItem.used = true;
                            foundFlag = true; // Now that it's found, set all subsequent elements to used as well
                            sequentialTracker = i;
                            //if (i == buffer.Count - 1)
                            //{
                            //    watchlist.Add(inputName);
                            //}
                            watchlist.Add(inputName);
                        }
                    }
                    else
                    {
                        if (i > sequentialTracker + 1)
                        {
                            return;
                        }
                        if (curItem.inputName == inputName)
                        {
                            curItem.used = true;
                            sequentialTracker++;
                        }
                    }
                }
            }
        }
        private void UpdateMovement(List<BufferItem> frameBuffer, string[] readBuffer)
        {
            BufferItem item = new BufferItem();

            if(readBuffer != null)
            {
                if (readBuffer[0] == "Left") _horizontal = -1;
                else if (readBuffer[0] == "Right") _horizontal = 1;
                else _horizontal = 0;
            }

            item.val = _horizontal;
            if (_horizontal > 0)
                item.inputName = "Right";
            else if (_horizontal < 0)
                item.inputName = "Left";
            else
                item.inputName = "Neutral";
            
            frameBuffer.Add(item);

            item = new BufferItem();

            if (readBuffer != null)
            {
                if (readBuffer[1] == "Up") _vertical = 1;
                else if (readBuffer[1] == "Down") _vertical = -1;
                else _vertical = 0;
            }

            item.val = _vertical;
            if (_vertical > 0)
                item.inputName = "Up";
            else if (_vertical < 0)
                item.inputName = "Down";
            else
                item.inputName = "Neutral";
            frameBuffer.Add(item);
        }
        private void UpdateJump(List<BufferItem> frameBuffer, string[] readBuffer)
        {
            if (readBuffer != null)
            {
                _jump = 0;
                for (int i = 2; i < readBuffer.Length; i++)
                {
                    if (readBuffer[i] == "Jump") _jump = 1;
                }
            }
            if (_jump > 0)
            {
                
                BufferItem item = new BufferItem();

                item.val = _jump;
                item.inputName = "Jump";
                if (watchlist.Contains(item.inputName))
                {
                    item.used = true;
                }
                    
                frameBuffer.Add(item);
            }
        }
        private void UpdateDash(List<BufferItem> frameBuffer, string[] readBuffer)
        {
            if (readBuffer != null)
            {
                _dash = 0;
                for (int i = 2; i < readBuffer.Length; i++)
                {
                    if (readBuffer[i] == "Dash") _dash = 1;
                }
            }
            if (_dash > 0)
            {
                BufferItem item = new BufferItem();
                item.val = _dash;
                item.inputName = "Dash";
                if (watchlist.Contains(item.inputName))
                    item.used = true;
                frameBuffer.Add(item);
            }
        }
        private void UpdateLightAttack(List<BufferItem> frameBuffer, string[] readBuffer)
        {
            if (readBuffer != null)
            {
                _lightAttack = 0;
                for (int i = 2; i < readBuffer.Length; i++)
                {
                    if (readBuffer[i] == "LightAttack") _lightAttack = 1;
                }
            }
            if (_lightAttack > 0)
            {
                BufferItem item = new BufferItem();
                item.val = _lightAttack;
                item.inputName = "LightAttack";
                if (watchlist.Contains(item.inputName))
                    item.used = true;
                frameBuffer.Add(item);
            }
        }
        private void UpdateMediumAttack(List<BufferItem> frameBuffer, string[] readBuffer)
        {
            if (readBuffer != null)
            {
                _mediumAttack = 0;
                for (int i = 2; i < readBuffer.Length; i++)
                {
                    if (readBuffer[i] == "MediumAttack") _mediumAttack = 1;
                }
            }
            if (_mediumAttack > 0)
            {
                BufferItem item = new BufferItem();
                item.val = _mediumAttack;
                item.inputName = "MediumAttack";
                if (watchlist.Contains(item.inputName))
                    item.used = true;
                frameBuffer.Add(item);
            }
        }
        private void UpdateHeavyAttack(List<BufferItem> frameBuffer, string[] readBuffer)
        {
            if (readBuffer != null)
            {
                _heavyAttack = 0;
                for (int i = 2; i < readBuffer.Length; i++)
                {
                    if (readBuffer[i] == "HeavyAttack") _heavyAttack = 1;
                }
            }
            if (_heavyAttack > 0)
            {
                BufferItem item = new BufferItem();
                item.val = _heavyAttack;
                item.inputName = "HeavyAttack";
                if (watchlist.Contains(item.inputName))
                    item.used = true;
                frameBuffer.Add(item);
            }
        }
        public void OnEnable()
        {
            inputs.Enable();
        }
        public void OnDisable()
        {
            if(sr != null)sr.Close();
            if(sw != null)
            {
                sw.WriteLine("END");
                sw.Close();
                string newName = prepath + "/outBuffer_" +
                System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + "_" +
                System.DateTime.Now.TimeOfDay.Hours + "-" + System.DateTime.Now.TimeOfDay.Minutes + "-" + System.DateTime.Now.Second + ".txt";
                File.Copy(path, newName);
                File.Delete(path);
            }
            fs.Close();
            
            inputs.Disable();
        }
        private void CreateText()
        {
            prepath = Application.dataPath;
            path = prepath + "/outBuffer.txt";
            string testPath = prepath + "/test.txt";
            if (File.Exists(testPath))
            {
                fs = new FileStream(testPath, FileMode.Open, FileAccess.Read);
                scriptPresent = true;
                sr = new StreamReader(fs);
            }
            else
            {
                if (File.Exists(path)) File.Delete(path);
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
            }
        }
    }
}