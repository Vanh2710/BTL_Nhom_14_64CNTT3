using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgSender : MonoBehaviour
{
    [Header("DmgSender")]
    public int dmg = 1;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
      this.ColliderSendDmg(collision);
    }

    protected virtual void ColliderSendDmg(Collider2D collision)
    {
        DmgReceiver dmgReceiver = collision.GetComponent<DmgReceiver>();
        if (dmgReceiver == null) return;

        dmgReceiver.Receive(this.dmg);

    }
}
