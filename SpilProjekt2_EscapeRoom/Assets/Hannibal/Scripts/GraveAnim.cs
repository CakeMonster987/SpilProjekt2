using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveAnim : MonoBehaviour
{
    private Animator anim;

    private bool graveOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void graveAnimator()
    {
        graveOpen = !graveOpen;
        anim.SetBool("GraveOpen", graveOpen);
    }
}
