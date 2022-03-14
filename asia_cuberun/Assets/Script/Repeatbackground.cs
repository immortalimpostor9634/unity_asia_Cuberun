using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeatbackground : MonoBehaviour
{
    private Vector3 startPos;

    private float repeatWidth;
    void Start()
    {
        // 取得座標
        startPos = transform.position;

        // 取得碰撞器x軸1/2的位置
        repeatWidth = GetComponent<BoxCollider>().size.x/2;
    }

    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
