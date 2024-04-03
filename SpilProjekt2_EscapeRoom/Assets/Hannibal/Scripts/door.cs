using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    bool OpenDoor = false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
   
    }
    public void toggleDoor()
    {
        OpenDoor =!OpenDoor;
        anim.SetBool("OpenDoor", OpenDoor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
