using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextleveleffectspawner : MonoBehaviour {
    
    float timebetwwenspawns;
    [SerializeField]
    float starttimebetweenspawns;
    [SerializeField]
    GameObject [] effect;
    [SerializeField]
    GameObject effect1;
    [SerializeField]
    GameObject effect2;
    [SerializeField]
    GameObject effect3;

    [Header("randomness")]
    [SerializeField]
    float maxx;
    [SerializeField]
    float minx;
    [SerializeField]
    float maxy;
    [SerializeField]
    float miny;
    float randomized;


    // Use this for initialization
    void Start () {
        randomized = starttimebetweenspawns;
	}
	
	// Update is called once per frame
	void Update () {
        if (timebetwwenspawns >= randomized)
        {
            Vector3 Pos = transform.position + new Vector3(Random.Range(minx,maxx), Random.Range(miny, maxy), 0);
            Instantiate(effect[Random.Range(0,4)], Pos, Quaternion.identity);
            timebetwwenspawns = 0;
            randomized = Random.Range(0,starttimebetweenspawns);
        }
        else
        {
            timebetwwenspawns += Time.deltaTime;
        }
	}
}
