using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycodeManager : Singleton<KeycodeManager>
{
    


    internal KeyCode GetKeycode(string v)
    {
        //throw new NotImplementedException();
        if (v == "HeroWalkLeft")
        {
            return KeyCode.A;
        }
        if (v == "HeroWalkRight")
        {
            return KeyCode.D;
        }


        return 0;


    }
}
