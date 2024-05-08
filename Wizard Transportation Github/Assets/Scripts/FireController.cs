using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("IsDashing", isDashing);
    }
}
