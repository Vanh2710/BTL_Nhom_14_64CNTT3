using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    private List <GameObject> minion;
    public GameObject minionPrefab;
    protected float spawnTimer = 0f;
    protected float spawnDelay = 1f;

    private void Start()
    {
        this.minion = new List<GameObject>();
    }

    void Update()
    {
        this.Spawn();

        this.CheckMinionDead();

    }
    void Spawn()
    {
        this.spawnTimer += Time.deltaTime;
        if (this.spawnTimer < this.spawnDelay) return;
        this.spawnTimer = 0;

        if (this.minion.Count >= 3) return;

        int index = this.minion.Count + 1;
        GameObject minion = Instantiate (this.minionPrefab);
        minion.name = "Bom #" + index;

        minion.transform.position = transform.position;
        minion.gameObject.SetActive(true);

        this.minion.Add(minion);
    }

    void CheckMinionDead()
    {
        GameObject minions;
        for (int i=0; i < this.minion.Count; i++)
        {
            minions = this.minion[i];
            if (minions == null) this.minion.RemoveAt(i);
        }
    }

}
