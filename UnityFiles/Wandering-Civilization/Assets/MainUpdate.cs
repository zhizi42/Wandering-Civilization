using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUpdate : Singleton<MainUpdate>
{
    public GameObject character;

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdated");
        GameController.Instance.OnUpdate();
        character.GetComponent<Character>().OnWalk();
    }
}
