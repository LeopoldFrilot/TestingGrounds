
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public List<GameObject> inputList;
    private List<string> prevActionList;
    private List<string> actionList;
    public void Start()
    {
        PC = FindObjectOfType<PlayerController>();
    }
    public void Update()
    {
        if (transform.childCount >= historyLength)
        {
            Destroy(transform.GetChild(0).gameObject); // Cull children
        }
        bool res1 = PopulateDirection();
        bool res2 = PopulateActions();
        if(res1 || res2)
        {
            var inputs = transform.GetComponentsInChildren<InputSign>();
            Debug.Log(inputs.Length);
            foreach(InputSign input in inputs)
            {
                Debug.Log("Hi");
                input.DownShift();
            }
        }
    }

    private bool PopulateDirection()
    {
        if (PC.curDirectionalOption != prevInput)
        {
            GameObject newInput = Instantiate(buttonPrefab, transform);
            Image inputImage = newInput.transform.GetChild(0).GetComponent<Image>();
            switch (PC.curDirectionalOption)
            {
                case "Right":
                    inputImage.sprite = rightSprite;
                    break;
                case "DownRight":
                    inputImage.sprite = downRightSprite;
                    break;
                case "Down":
                    inputImage.sprite = downSprite;
                    break;
                case "DownLeft":
                    inputImage.sprite = downLeftSprite;
                    break;
                case "Left":
                    inputImage.sprite = leftSprite;
                    break;
                case "UpLeft":
                    inputImage.sprite = upLeftSprite;
                    break;
                case "Up":
                    inputImage.sprite = upSprite;
                    break;
                case "UpRight":
                    inputImage.sprite = upRightSprite;
                    break;
                case "QCRBottom":
                    inputImage.sprite = quaCircleRightBottomSprite;
                    break;
                case "QCLBottom":
                    inputImage.sprite = quaCircleLeftBottomSprite;
                    break;
                case "QCRTop":
                    inputImage.sprite = quaCircleRightTopSprite;
                    break;
                case "QCLTop":
                    inputImage.sprite = quaCircleLeftTopSprite;
                    break;
                default:
                    inputImage.sprite = neutralSprite;
                    break;
            }
            inputList.Add(newInput);
            prevInput = PC.curDirectionalOption;
            return true;            
        }
        return false;
    }

    private bool PopulateActions()
    {
        int count = 0;
        
        if (PC.usedInputs.Contains("Jump"))
        {
            if(!prevActionList.Contains("Jump"))
            {
                GameObject newInput = Instantiate(buttonPrefab, transform);
                Image inputImage = newInput.transform.GetChild(0).GetComponent<Image>();
                inputImage.sprite = jumpSprite;
                count++;
                newInput.GetComponent<InputSign>().LeftShift(count);
                inputList.Add(newInput);
            }
            actionList.Add("Jump");
        }
        prevActionList = actionList;
        actionList.Clear();
        PC.usedInputs.Clear();
        if (count > 0) return true;
        return false;
    }
}
