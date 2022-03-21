using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveingLeft : MonoBehaviour
{
    public float speed = 20;

    private Charactercontroler playerControllerScript;

    public float leftBound = -15;

    void Start()
    {
        //因為欲取得非本script所掛載的遊戲物件之元件，故使用此方法來撰寫
        playerControllerScript=GameObject.Find("PLAYER").GetComponent<Charactercontroler>();
    }

    void Update()
    {
        if(playerControllerScript.gameOver==false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
        if(gameObject.transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            print("障礙物刪除");
        }
    }
}
