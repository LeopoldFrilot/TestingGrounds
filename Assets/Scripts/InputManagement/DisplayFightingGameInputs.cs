
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InputManagement.Buffer
{
    public class DisplayFightingGameInputs : MonoBehaviour
    {
        [SerializeField] GameObject buttonPrefab;
        [SerializeField] [Range(7, 30)] int historyLength = 20;
        [Header("Direction")]
        [SerializeField] Sprite neutralSprite;
        [SerializeField] Sprite rightSprite;
        [SerializeField] Sprite downRightSprite;
        [SerializeField] Sprite downSprite;
        [SerializeField] Sprite downLeftSprite;
        [SerializeField] Sprite leftSprite;
        [SerializeField] Sprite upLeftSprite;
        [SerializeField] Sprite upSprite;
        [SerializeField] Sprite upRightSprite;
        [Header("Special Direction")]
        [SerializeField] Sprite quaCircleRightBottomSprite;
        [SerializeField] Sprite quaCircleRightTopSprite;
        [SerializeField] Sprite quaCircleLeftBottomSprite;
        [SerializeField] Sprite quaCircleLeftTopSprite;
        [Header("Actions")]
        [SerializeField] Sprite jumpSprite;
        [SerializeField] Sprite dashSprite;
        [SerializeField] Sprite lightAttackSprite;
        [SerializeField] Sprite mediumAttackSprite;
        [SerializeField] Sprite heavyAttackSprite;

        PlayerController PC;
        string prevInput;
        public List<string> prevActionList;
        public List<string> actionList;

        public void Start()
        {
            PC = FindObjectOfType<PlayerController>();
            prevActionList.Add("");
            actionList.Add("");
        }
        public void LateUpdate()
        {
            bool res1 = PopulateDirection();
            bool res2 = PopulateActions();
        
            if(res1 || res2)
            {
                var inputs = transform.GetComponentsInChildren<InputSign>();
                foreach(InputSign input in inputs)
                {
                    input.DownShift();
                    if (input.age > historyLength) Destroy(input.gameObject);
                }
            }
        }

        private bool PopulateDirection()
        {
            if (PC.curDirectionalOption != prevInput)
            {
                GameObject newInput = Instantiate(buttonPrefab, transform);
                Image inputImage = newInput.transform.GetChild(0).GetComponent<Image>();
                inputImage.sprite = ChooseDirSprite(PC.curDirectionalOption);
            
                prevInput = PC.curDirectionalOption;
                return true;            
            }
            return false;
        }

        private bool PopulateActions()
        {
            int count = 0;

            count = PopulateAction("Jump", count, jumpSprite);
            count = PopulateAction("Dash", count, dashSprite);
            count = PopulateAction("LightAttack", count, lightAttackSprite);
            count = PopulateAction("MediumAttack", count, mediumAttackSprite);
            count = PopulateAction("HeavyAttack", count, heavyAttackSprite);

            prevActionList.Clear();
            foreach(string action in actionList) { prevActionList.Add(action); }
            actionList.Clear();
            if (count > 0)
            {
                GameObject newInput = Instantiate(buttonPrefab, transform);
                Image inputImage = newInput.transform.GetChild(0).GetComponent<Image>();
                inputImage.sprite = ChooseDirSprite(PC.curDirectionalOption);
                return true;
            }

            return false;
        }
        private int PopulateAction(string actionName, int num, Sprite sprite)
        {
            if (PC.usedInputs.Contains(actionName))
            {
                if (!prevActionList.Contains(actionName))
                {
                    GameObject newInput = Instantiate(buttonPrefab, transform);
                    Image inputImage = newInput.transform.GetChild(0).GetComponent<Image>();
                    inputImage.sprite = sprite;
                    num++;
                    newInput.GetComponent<InputSign>().LeftShift(num);
                }
                actionList.Add(actionName);
            }
            return num;
        }

        private Sprite ChooseDirSprite(string dir)
        {
            switch (dir)
            {
                case "Right":
                    return rightSprite;
                case "DownRight":
                    return downRightSprite;
                case "Down":
                    return downSprite;
                case "DownLeft":
                    return downLeftSprite;
                case "Left":
                    return leftSprite;
                case "UpLeft":
                    return upLeftSprite;
                case "Up":
                    return upSprite;
                case "UpRight":
                    return upRightSprite;
                case "QCRBottom":
                    return quaCircleRightBottomSprite;
                case "QCLBottom":
                    return quaCircleLeftBottomSprite;
                case "QCRTop":
                    return quaCircleRightTopSprite;
                case "QCLTop":
                    return quaCircleLeftTopSprite;
                default:
                    return neutralSprite;
            }
        }
    }
}