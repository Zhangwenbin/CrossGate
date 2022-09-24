using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{

    public float moveSpeed;

    public Vector3 moveDir;

    public bool moveForward;
    // Update is called once per frame
    void Update()
    {
        if (moveForward)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
       
    }
}
