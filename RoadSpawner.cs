using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    //Định nghĩa các lớp đối tượng khác trong lớp RoadSpawner
    protected GameObject roadPrefab;
    protected GameObject roadSpawnPos;

    protected float distance = 0;
    protected GameObject roadCurrent;
    
    //Định nghĩa tầng của Road
    protected int roadLayerOrder = 0;

    private void Awake()
    {   

        //Tìm kiếm và định nghĩa 2 đối tượng RoadPrefab và RoadSpawnPos
        this.roadPrefab = GameObject.Find("RoadPrefab");
        this.roadSpawnPos = GameObject.Find("RoadSpawnPos");
        
        //Tắt object RoadPrefab
        this.roadPrefab.SetActive(false);
        
        //Gán những Road liên tục Spawn là RoadCurrent
        this.roadCurrent = this.roadPrefab;

        //Tự động thay đổi tạo độ z theo object RoadPrefab
        this.roadLayerOrder = (int) this.roadPrefab.transform.position.z;

        //Khởi tạo Road ban đầu 
        this.Spawn(this.roadPrefab.transform.position);
    }

    private void FixedUpdate()
    {
        this.UpdateRoad();
    }

    protected virtual void UpdateRoad()
    {
        ////Gọi 1 biến khoảng cách sẽ follow tọa độ của Player khi chạy
        this.distance = Vector2.Distance(PlayerController.instance.transform.position, this.roadCurrent.transform.position);
        
        //Nếu khoảng cách lên hơn 40 tạo thêm Road
        if (this.distance > 40) this.Spawn();    
    }

    //Hàm tạo Road bằng biến roadSpawnPos
    protected virtual void Spawn()
    {
        Vector3 pos = this.roadSpawnPos.transform.position;
        pos.x = 0;
        pos.z = this.roadLayerOrder;

        this.Spawn(pos);
       
    }


    //Hàm tạo Road khi chạy chương trình để thêm Road vào sau Road ban đầu
    protected virtual void Spawn(Vector3 position)
    {
        this.roadCurrent = Instantiate(this.roadPrefab, position, this.roadPrefab.transform.rotation);

        //Gán quan hệ giữa RoadSpawner với clone nó tạo ra
        this.roadCurrent.transform.parent = transform;

        this.roadCurrent.SetActive(true);
    }
}
