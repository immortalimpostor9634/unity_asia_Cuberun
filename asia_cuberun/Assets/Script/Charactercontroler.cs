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

    private Animator playerAnim;    //控制角色動畫

    public ParticleSystem ps_explosion;   //定義控制爆炸粒子物件的變數

    public ParticleSystem ps_drit;  //定義飛濺粒子特效的變數

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
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * 10,ForceMode.Impulse);

            isOnGround = false;

            //透過#Animator視窗的Parameters籤頁可知Jump_trig變數
            playerAnim.SetTrigger("Jump_trig");

            ps_drit.Stop();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;  //避免二段跳

            ps_drit.Play();
        }
        else if(other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            print("遊戲結束");

            playerAnim.SetBool("Death_b",true);

            playerAnim.SetInteger("Death_int",1); 

            ps_explosion.Play();

            ps_drit.Stop();
        }
    }

}
