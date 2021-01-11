using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOptions : MonoBehaviour
{
    PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<PlayerController>();
    }

    public bool LightAttack()
    {
        PC.animator.SetTrigger("LightAttack");
        return true;
    }
}
