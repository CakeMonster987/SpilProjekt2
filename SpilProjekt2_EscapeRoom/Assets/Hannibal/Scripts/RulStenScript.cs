using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulStenScript : MonoBehaviour
{

    public Animator StenAni;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            StenAni.SetBool("RulSten", true);
        }
    }
}
