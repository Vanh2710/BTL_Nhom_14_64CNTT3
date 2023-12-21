using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Spawner")]
    public GameObject objPrefab;
    public GameObject spawnPos;
    public List<GameObject> objects;
    public float spawnTimer = 0f;
    public float spawnDelay = 1f;
    public string spawnPosName = "";
    public string prefabName = "";

    public int maxObj = 1;

    public int layerOrder = 0;

    private void Awake()
    {
        this.objects = new List<GameObject>();
        this.spawnPos = GameObject.Find(this.spawnPosName);
        this.objPrefab = GameObject.Find(this.prefabName);
        this.objPrefab.SetActive(false);
        this.layerOrder = (int) this.objPrefab.transform.position.z;
    }

    private void Update()
    {
        this.CheckDead();
        this.Spawn();
    }


    protected virtual GameObject Spawn()
    {
        //Nếu Player đã hết máu thì không cần Spawn nữa
        if (PlayerController.instance.dmgReceiver.IsDead()) return null;
        
        //Giới hạn chỉ spawn 1 object 1 lần
        if(this.objects.Count >= this.maxObj) return null;

        //Dùng để delay thời gian tạo ra object
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return null;
        this.spawnTimer = 0;

        Vector3 pos = this.spawnPos.transform.position;
        pos.z = this.layerOrder;
        return this.Spawn(pos);
    }
    protected virtual GameObject Spawn(Vector3 pos)
    {
        

        //Object ngay khi được spawn ra sẽ tìm tới vị trí của Player
        GameObject obj = Instantiate(this.objPrefab);
        obj.transform.position = pos;
        
        //Gán quan hệ giữa Object với clone nó tạo ra
        obj.transform.parent = transform;

        obj.SetActive(true);

        //Thêm Object
        this.objects.Add(obj);

        return obj;
    }

    protected virtual void CheckDead()
    {
        GameObject minions;
        for (int i=0; i < this.objects.Count; i++)
        {
            minions = this.objects[i];
            if (minions == null) this.objects.RemoveAt(i);
        }
    }
}
