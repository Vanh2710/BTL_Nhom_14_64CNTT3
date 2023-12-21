using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgSender : DmgSender
{
    [Header("Enemy")]
    public EnemyController enemyCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyController>();
    }
    
    protected override void ColliderSendDmg(Collider2D collision)
    {
        base.ColliderSendDmg(collision);

        this.enemyCtrl.dmgReceiver.Receive(1);
    }

    
}
