using UnityEngine;


public class man : MonoBehaviour
{
    #region//variable
    #region//hook
    [Header("Hook")]
   [SerializeField] SpringJoint2D springjoint;
    float distance = Mathf.Infinity ;
    GameObject[] hooks; //array of hooks
    GameObject ClosestHook;
    GameObject currenthook;
    GameObject LastClosestHook;
    HookAnchor hookanchor;
    HookAnchor lasthookanchor;
    [SerializeField] Rigidbody2D rb;
    Rigidbody2D rb2d;
    
    Vector2 currenthookpoeition;
    bool ishooked = false;
    bool justhooked = false;
    bool justaddedforce = false;
    bool justunhooked = false;
    [SerializeField]
    float offset = 0.5f;
    [SerializeField]
    Transform pointertrn;
    #endregion

    #region//spriteschanging
    [Header("sprites")]
    [SerializeField] SpriteRenderer spr;
    [SerializeField]
    Sprite idle;
    [SerializeField]
    Sprite back;
    [SerializeField]
    Sprite middle;
    [SerializeField]
    Sprite front;
    [SerializeField]
    Sprite winningSprite;
    [SerializeField]
    CircleCollider2D idleol;
    [SerializeField]
    CircleCollider2D othercol;
    bool won =false;
    #endregion
    
    #region//other parameteres

    [Header("other parameteres")]
 float push = 1.3f;
    [SerializeField]
    float killzone = 3;
    #endregion
    #region//effects
    [Header("Effects")]
    [SerializeField]
    GameObject winningparticles;
    bool justspawned = false;
    #endregion
    GameObject gmgo;
    GameManager gm;
    GameObject lrgo;
    LineRenderer lr;

    #endregion

    float max = 50;

    Vector2 vel =  Vector2.zero;

    void Start ()
    {
        destroylr();
        lr = lrgo.GetComponent<LineRenderer>();
        lr.enabled = false;
        gmgo = GameObject.FindGameObjectWithTag("GameManager");
        gm = gmgo.GetComponent<GameManager>();
        hooks = GameObject.FindGameObjectsWithTag("Hook");
    }

    void Update()
    {
            distance = Mathf.Infinity;
            distancecheck();
            

            spritechanging();

            colliderchanging();

            linerendrercall();

        if (transform.position.y <= -killzone && !win.wonlevl)
        {
            foreach (GameObject hook in hooks)
            {
                hookanchor = hook.GetComponent<HookAnchor>();
                hookanchor.isnothookedtothis();
                hookanchor.isnotclosetothis();
            }
            gm.respawn();
            Destroy(gameObject);
        }

        else if (!win.wonlevl)
        {

#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
            {
                attach();
            }
            if (Input.GetMouseButtonUp(0) || Input.GetButtonUp("Jump"))
            {
                release();
                vel = rb.velocity;
            }

// #elif UNITY_ANDROID
        // if (Input.touchCount > 0 )
        // {
        //     Touch touch = Input.GetTouch(0);
        //     if (touch.phase == TouchPhase.Began && touch.position.y < Screen.height/2)
        //     {
        //         attach();
        //     }
        //     if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        //     {
        //         release();
        //     }
        //  }
#endif
        }

        else if(win.wonlevl)
        {
            
            if (!justspawned)
            {
                spawnparticles();
                Vector2 diff = rb.velocity;
                diff.Normalize();
                float rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotz - 90);
                
            }
        }
           
        }
        
    void FixedUpdate()
    { 
        if (rb.velocity.magnitude > max )
        {
            foreach (GameObject hook in hooks)
            {
                hookanchor = hook.GetComponent<HookAnchor>();
                hookanchor.isnothookedtothis();
                hookanchor.isnotclosetothis();
            }
            gm.respawn();
            Destroy(gameObject);
        }
        
        else if (win.wonlevl)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, 0.1f * Time.deltaTime);
           
        }
      
        else if (ishooked &&  !justaddedforce && rb.velocity.magnitude < 15 && justhooked)
        {
            justaddedforce = true;
            //rb.velocity = rb.velocity * 1.3f; 
            rb.velocity = Vector2.Lerp(rb.velocity, rb.velocity * 1.3f, 0.1f * Time.deltaTime);
            
            
           
            #region
            
            // if (transform.position.x < ClosestHook.transform.position.x && transform.position.y < ClosestHook.transform.position.y)//set back sprite for the character
            // {
            //     rb.velocity = rb.velocity * push;
            //     //rb.AddForce(forc);
            //     justhooked = false;
            // }

            // else if (transform.position.x > ClosestHook.transform.position.x && transform.position.y < ClosestHook.transform.position.y)//set front sprite for the character
            // {
            //     rb.velocity = rb.velocity * push;
            //     //rb.velocity = Vector2.zero;
            //     //rb.AddForce(-forc);
            //     justhooked = false;
            // }
            // else if (transform.position.y > ClosestHook.transform.position.y)
            // {
            //     rb.velocity = rb.velocity * push;
            //     //rb.velocity = Vector2.zero;
            //     //rb.AddForce(-downfrc);
            //     justhooked = false;
            // }
            
            

            #endregion
            
        }
        else if (justunhooked)
        {
            justunhooked = false;
            rb.velocity = vel;
        }
        
    }

    void spawnparticles()
    {
        if (!justspawned)
        {
            Vector2 diff = rb.velocity;
            diff.Normalize();
            float rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            Instantiate(winningparticles, transform.position, Quaternion.Euler(0f, 0f, rotz));
            justspawned = true;
        }
    }

    void distancecheck()
    {
        // if (!ishooked)
        // {
            Vector3 position = transform.position;
            foreach (GameObject hook in hooks)
            {
                Vector3 diff = hook.transform.position - position;
                float curdistance = diff.sqrMagnitude;
                if (curdistance < distance)
                {

                    if (hook != ClosestHook && ClosestHook != null)
                    {
                        LastClosestHook = ClosestHook;
                        lasthookanchor = LastClosestHook.GetComponent<HookAnchor>();
                        lasthookanchor.isnotclosetothis();
                    }
                    distance = curdistance;
                    ClosestHook = hook;
                    hookanchor = hook.GetComponent<HookAnchor>();
                    hookanchor.isclosetothis();
                    if (!ishooked)
                    {
                    currenthook = hook;
                    currenthookpoeition = currenthook.transform.position;
                    rb2d = currenthook.GetComponent<Rigidbody2D>();
                    }
                }
            }
        // }
        // else
        // {

        // }
    }

    void attach()
    {
        justhooked = true;
        ishooked = true;
        springjoint.enabled = true;
        springjoint.connectedBody = rb2d;
        hookanchor.ishookedinthis(); 
    }

    void release()
    {
        springjoint.enabled = false;
        justhooked = false;
        justaddedforce = false;
        ishooked = false;
        justunhooked = true;
        hookanchor.isnothookedtothis();
        foreach (GameObject hook in hooks)
        {
            hookanchor = hook.GetComponent<HookAnchor>();
            hookanchor.isnothookedtothis();
            hookanchor.isnotclosetothis();
        }
        if (LastClosestHook != null)
        {
            lasthookanchor.isnothookedtothis();
        }
        
    }

    void colliderchanging()
    {
        if (ishooked == true)
        {  
            othercol.enabled = true;
            idleol.enabled = false;
        }
        else
        {
            othercol.enabled = false;
            idleol.enabled = true;
        }
    }

    void spritechanging()
    {
        if (win.wonlevl)
        {
            release();
            spr.sprite = winningSprite;
        }
        else
        {
            if (ishooked == false)
            {
                spr.sprite = idle;
            }
            else
            {
                Vector2 diff = transform.position - currenthook.transform.position;
                diff.Normalize();
                float rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, rotz + 90);
                //set sprite for the character
                if (transform.position.x < currenthook.transform.position.x - offset)//set back sprite for the character
                {
                    spr.sprite = back;
                    //sprndr.sprite = null;
                }

                else if (transform.position.x > currenthook.transform.position.x + offset)//set front sprite for the character
                {
                    spr.sprite = front;
                    //  sprndr.sprite = null;
                }

                else/* if (transform.position.x == closest.transform.position.x)*/ //set middle sprite for the character
                {
                    spr.sprite = middle;
                    //   sprndr.sprite = null;
                }
            }
        }
    }

    void linerendrercall()
    {
        if (ishooked == true)
        {
            lr.enabled = true;
            lr.SetPosition(0, pointertrn.position);
            lr.SetPosition(1, currenthookpoeition);
        }
        else
        {
            lr.enabled =false;
        }
    }
        
    void destroylr()
    {
        if (lrgo == null)
        {
            lrgo = GameObject.FindGameObjectWithTag("linerendrerGO");
        }
    }   
}