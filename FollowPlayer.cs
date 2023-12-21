using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    //Tốc độ của Enemy
    public float speed = 27f;

    //Khoảng cách giữa Enemy và Player
    public float disLimit = 6f;
    
    //Định nghĩa biến Random
    public float randPos = 0;

    private void Awake()
    {
        //Random vị trí Enemy xuất hiện theo tọa độ Y
        this.randPos = Random.Range(-6,6);
    }
   
    private void FixedUpdate()
    {
        this.Follow();

        
    }

    //Enemy di chuyển theo Player
    private void Follow()
    {
        //Lựa chọn vị trí spawn ngẫu nhiên cho EnemyPrefab
        Vector3 pos = PlayerController.instance.transform.position;
        pos.x = this.randPos;

        //Bám theo vị trí của Player
        Vector3 distance = pos - transform.position;

        //Nếu khoảng cách yêu cầu đã đủ thì giữ nguyên vị trí của EnemyPrefab
        if (distance.magnitude >= this.disLimit)
        {
            Vector3 targetPoint = pos - distance.normalized * this.disLimit;
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, this.speed * Time.deltaTime);
        }
    }
}
