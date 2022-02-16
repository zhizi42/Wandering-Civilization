using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charaName = "测试员";
    public float speed = 35.0f;
    //(other fields)
    private int nowFoward = 1;
    bool onWalk = false;

    public void Walk(int foward) 
    {
        nowFoward = foward;
        onWalk = true;

    }/*由控制器调用*/
    public void OnWalk() 
    {
        if (onWalk)
        {
            //Debug.LogWarning(nowFoward * Time.fixedDeltaTime);
            gameObject.transform.position = gameObject.transform.position + new Vector3(nowFoward * speed * 0.05f * Time.fixedDeltaTime, 0);
            //Debug.LogWarning(gameObject.transform.position);

            //Debug.Log("OnWalk");
        }
        onWalk = false;
    
    }/*由游戏主更新器调用*/
    public void Damaged(float DamagedValue) { }
    //(other methods)
}