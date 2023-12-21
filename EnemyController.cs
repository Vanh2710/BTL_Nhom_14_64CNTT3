using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Despawner despawner;

    public EnemyDmgReceiver dmgReceiver;

    //Tạo liên kết 
    private void Awake()
    {
        this.despawner = GetComponent<Despawner>();

        this.dmgReceiver = GetComponent<EnemyDmgReceiver>();
    }
   
    
}
