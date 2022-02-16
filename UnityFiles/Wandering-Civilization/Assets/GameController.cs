using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    //(fields)
    public GameObject character;



    public void OnUpdate()/*由游戏主更新器调用*/
    {
        //一个示意，通过实时获取操作的按键来实现操作改键
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