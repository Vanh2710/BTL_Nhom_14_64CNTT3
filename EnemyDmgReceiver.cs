using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmgReceiver : DmgReceiver
{
    [Header("Enemy")]
    public EnemyController enemyCtrl;

    private void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyController>();
    }

    private void Reset()
    {
        this.hp = 3;
    }
    
    public override void Receive(int dmg)
    {
        base.Receive(dmg);
        if (this.IsDead()) this.enemyCtrl.despawner.Despawn();
    }
}
