using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Animator animator;
    public bool isFiring;
    public GameObject GameManager;
    // Update is called once per frame
    private void FixedUpdate()
    {
        animator.SetBool("IsFiring", isFiring);
    }
}
