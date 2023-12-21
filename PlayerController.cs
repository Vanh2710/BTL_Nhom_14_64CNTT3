using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;

    public DmgReceiver dmgReceiver;
    public PlayerStatus playerStatus;

    private void Awake()
    {
        PlayerController.instance = this;

        this.dmgReceiver = GetComponent<DmgReceiver>();
        this.playerStatus = GetComponent<PlayerStatus>();
    }
}
