using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgReceiver : MonoBehaviour
{
    [Header("DmgReceiver")]
    public int hp = 1;
   
    //Hàm ảo tạo ra nhầm xác định xem Player chết hay chưa (chết = true, sống = false)
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    //Hàm ảo khiến Player nhận sát thương
    public virtual void Receive(int dmg)
    {
        this.hp -= dmg;
    }
}
