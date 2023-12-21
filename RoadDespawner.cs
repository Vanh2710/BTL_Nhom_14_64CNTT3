using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadDespawner : MonoBehaviour
{

    //Định nghĩa biến khoảng cách
    protected float distance = 0;


    
    private void FixedUpdate()
    {
        this.UpdateRoad();
    }


    protected virtual void UpdateRoad()
    {
        //Gọi 1 biến khoảng cách sẽ follow tọa độ của Player khi chạy
        this.distance = Vector2.Distance(PlayerController.instance.transform.position, transform.position);
        
        //Nếu khoảng cách lên hơn 100 sẽ xóa bớt Road
        if (this.distance > 100) this.Despawn();    
    }

    //Hàm xóa Road
    protected virtual void Despawn()
    {
        Destroy(gameObject);
    }
}
