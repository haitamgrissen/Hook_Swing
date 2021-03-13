using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject player;
    [Header("camera settings")]
    
    [SerializeField]
    float smoothspeed = 10;
    [SerializeField]
    float Xoffset = -1f;
    [SerializeField]
    Animator animator;
    
  
    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
       

        if (player != null)
        {
            if (win.wonlevl)
            {
                Vector3 pos = transform.position;
                pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothspeed * Time.deltaTime);
                pos.y = Mathf.Lerp(transform.position.y, player.transform.position.y, smoothspeed * Time.deltaTime);

                animator.SetBool("zoom", true);
                transform.position = pos;
            }
            else
            {
                Vector3 pos = transform.position;
                pos.x = Mathf.Lerp(transform.position.x, player.transform.position.x + Xoffset, smoothspeed * Time.deltaTime);
                transform.position = pos;
            }
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void retarget()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
}

   