using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string charaName = "����Ա";
    public float speed = 35.0f;
    //(other fields)
    private int nowFoward = 1;
    bool onWalk = false;

    public void Walk(int foward) 
    {
        nowFoward = foward;
        onWalk = true;

    }/*�ɿ���������*/
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
    
    }/*����Ϸ������������*/
    public void Damaged(float DamagedValue) { }
    //(other methods)
}