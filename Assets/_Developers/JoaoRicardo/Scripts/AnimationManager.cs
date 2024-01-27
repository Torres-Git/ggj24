using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Hold()
    {
        animator.SetTrigger("Hold");
    }

    public void Release()
    {
        animator.SetTrigger("Release");
    }
}
