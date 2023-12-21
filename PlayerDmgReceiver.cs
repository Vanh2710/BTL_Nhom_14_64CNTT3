using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmgReceiver : DmgReceiver
{
    protected PlayerController playerCtrl;

    //Nối PlayerDmgReceiver với PlayerController
    private void Awake()
    {
        this.playerCtrl = GetComponent<PlayerController>();
    }

     //Hàm ảo khiến Player khi nhận sát thương tới còn 0 hp thì console sẽ thông báo "Dead"
    public override void Receive(int dmg)
    {   
        base.Receive(dmg);
        if (this.IsDead()) 
        {
            this.playerCtrl.playerStatus.Dead();
            UIManager.instance.bnGameOver.SetActive(true);
        }
    }
}
