using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    public int health = 200;
    private int stamina;
    private int gold;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }
    }

    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }

}
