using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<Obstacle> Obstacles = null;

    [SerializeField] private float spawnPositionZ;

    [SerializeField] private float speed;

    private void Start()
    {
        System.Action action = SendNewPoolObject;
        InvokeRepeating(action.Method.Name, 0, 1);
    }
    public void SendNewPoolObject()
    {
        foreach (var item in Obstacles)
            if (!item.gameObject.activeSelf)
            {
                item.Init(new Vector3(0,0, spawnPositionZ), speed);
                return;
            }
        Debug.Log("no quedan mas go para esta pool");
    }

}
