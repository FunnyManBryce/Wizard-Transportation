using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Animator animator;
    public bool isFiring;
    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("IsFiring", isFiring);
    }
}
