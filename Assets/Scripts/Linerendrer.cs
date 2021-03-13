using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linerendrer : MonoBehaviour
{
    [SerializeField]
    LineRenderer lr;
    [SerializeField]
    float lrwidth = 0.01f;
    void Start()
    {      
        lr.startWidth = lrwidth;
        lr.endWidth = lrwidth;
        lr.startColor = Color.black;
        lr.endColor = Color.black;
        
    }
}
