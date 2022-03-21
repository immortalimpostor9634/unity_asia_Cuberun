using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactercontroler : MonoBehaviour
{
    private Rigidbody playerRB;

    public float jumpForce;     //跳躍力道

    public float gravityModifier;     //系統物理重力

    public bool isOnGround = true;     //檢測是否在地面

    public bool gameOver = false;    //改成public才能被外部城市所存取(ex:Moleft.cs存取)

    //Week-06控制角色動畫
    private Animator playerAnim;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;   
        //等同Physics.gravity * Physics.gravity = gravityModifier

        //將遊戲物件的Animator元件掛載到playerAnim變數上，有啟動變數的意思
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * 10,ForceMode.Impulse);

            isOnGround = false;

            //透過#Animator視窗的Parameters籤頁可知Jump_trig變數
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            print("遊戲結束");
        }
    }
}
