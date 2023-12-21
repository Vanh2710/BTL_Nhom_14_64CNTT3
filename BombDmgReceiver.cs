using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDmgReceiver : DmgReceiver
{
    
    //[Header("Bomb")]

    public override void Receive(int dmg)
    {
        base.Receive(dmg);
        if (this.IsDead()) Destroy(gameObject);
    }
}
