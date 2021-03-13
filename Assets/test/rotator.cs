using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    
    [SerializeField] float speed;
    [SerializeField] int direction;
    private void Start()
    {
        speed = Random.Range(100, 400);
        direction = Random.Range(-1,1);
        if (direction >= 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime*direction);
    }
}
