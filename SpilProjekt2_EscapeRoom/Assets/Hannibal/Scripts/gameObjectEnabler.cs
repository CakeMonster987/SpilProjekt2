using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectEnabler : MonoBehaviour
{
    public GameObject GameObject;
    public void onButtonPress()
    {
        GameObject.SetActive(true);
    }
}
