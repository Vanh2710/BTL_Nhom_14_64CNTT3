using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    protected PlayerController playerCtrl;

    //Nối PlayerController với PlayerStatus
    private void Awake()
    {
        this.playerCtrl = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    //In ra dòng "Dead"
    public virtual void Dead()
    {
        Debug.Log("Dead");
    }
}
