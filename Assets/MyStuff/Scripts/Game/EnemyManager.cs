using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject SpawnpointBase;

    [SerializeField] private List<Obstacle> Obstacles = null;

    [SerializeField] private float speed;

    [SerializeField] private float spawnTime;

    [SerializeField] private float addedmodif;

    private float dt = 0;

    private void Update()
    {
        if(!StateManager.InGame())
            return;
        if (dt<spawnTime)
        {
            dt += Time.deltaTime;
            return;
        }
        dt = 0;
        SendNewPoolObject();
        spawnTime -= addedmodif;
        speed += addedmodif;
    }

    private void SendNewPoolObject()
    {
        foreach (var item in Obstacles)
            if (!item.gameObject.activeSelf)
            {
                item.Init(SpawnpointBase.transform.position + new Vector3(Random.Range(-5,5),0,0), speed);
                return;
            }
        Debug.Log("no quedan mas go para esta pool");
    }

}
