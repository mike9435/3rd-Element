using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLeaf : MonoBehaviour
{
    private float randomAngle;
    // Start is called before the first frame update
    void Start()
    {
        randomAngle = Random.Range(0f, 360f);
        transform.Rotate(0, 0, randomAngle);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position,new Vector3(0,0,1), 500*Time.deltaTime);
    }
}
