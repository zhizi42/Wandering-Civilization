using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    //(fields)
    public GameObject character;



    public void OnUpdate()/*����Ϸ������������*/
    {
        //һ��ʾ�⣬ͨ��ʵʱ��ȡ�����İ�����ʵ�ֲ����ļ�
        if (Input.GetKey(KeycodeManager.Instance.GetKeycode("HeroWalkLeft")))
        //if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("GetA");
            character.GetComponent<Character>().Walk(-1);


        }
        if (Input.GetKey(KeycodeManager.Instance.GetKeycode("HeroWalkRight")))
        {
            //Debug.Log("GetD");

            character.GetComponent<Character>().Walk(1);
        }
        // ......
    }
}