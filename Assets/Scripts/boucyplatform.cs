using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boucyplatform : MonoBehaviour {

   
    [SerializeField]
    Animator animator;

   
    private void bc()
    {
        animator.SetBool("bounce", false);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            animator.SetBool("bounce", true);
            //Debug.Log("bounce");
            //bc();
            Invoke("bc",0.1f);

        }
    }

}
