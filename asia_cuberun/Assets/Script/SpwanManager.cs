using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    //定義用來存取 預製物 Prefab 的遊戲物件
    public GameObject obPrefab;

    public Vector3 spwanPos = new Vector3(30,0,0);
    

    public float startDelay = 2;
    public float repeatRate = 3;
    void Start()
    {
        InvokeRepeating("SpwanO",startDelay,repeatRate);
    }

    void Update()
    {

    }

    void SpwanO ()
    {
        //使用 Instantiate 函式，可用來生成其他遊戲物件 ( 通常是預製物 Prefabs )
        Instantiate(obPrefab,spwanPos,obPrefab.transform.rotation);

    }
}
