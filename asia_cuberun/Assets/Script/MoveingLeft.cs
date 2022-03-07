using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingLeft : MonoBehaviour
{
    public float speed = 20;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
