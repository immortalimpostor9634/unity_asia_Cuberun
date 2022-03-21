using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    //定義用來存取 預製物 Prefab 的遊戲物件
    public GameObject obPrefab;

    //定義生成物件的位置
    public Vector3 spwanPos = new Vector3(30,0,0);    

    public float startDelay = 2;
    public float repeatRate = 3;

    //宣告一個用來暫存其他程式的變數，以便將來進一步控制
    private Charactercontroler playerControllerSctipt;
    
    void Start()
    {
        InvokeRepeating("SpwanO",startDelay,repeatRate);

        //取得另一個遊戲物件Player中的程式PlayerController.cs
        playerControllerSctipt=GameObject.Find("PLAYER").GetComponent<Charactercontroler>();

    }

    void Update()
    {

    }

    void SpwanO ()
    {
        //使用 Instantiate 函式，可用來生成其他遊戲物件 ( 通常是預製物 Prefabs )
        if(playerControllerSctipt.gameOver==false)
        {
        Instantiate(obPrefab,spwanPos,obPrefab.transform.rotation);
        }

    }
}
