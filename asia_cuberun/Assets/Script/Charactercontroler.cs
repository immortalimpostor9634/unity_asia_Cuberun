using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroler : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce;     //跳躍力道

    public float gravityModifier;     //系統物理重力

    public bool isOnGround = true;     //檢測是否在地面

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;   
        //等同Physics.gravity * Physics.gravity = gravityModifier

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * 10,ForceMode.Impulse);

            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        isOnGround = true;

    }
}
