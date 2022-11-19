using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField,Range(-10,3)] float dieDistZ;
    Rigidbody rb = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (!StateManager.InGame())
            return;
        if (CompareDist())
            return;
        MoveBackward();
    }
    public void Init(Vector3 spawnPoint,float speed)
    {
        this.speed = speed;
        transform.position = spawnPoint;
        gameObject.SetActive(true);
    }

    #region PRIVATE_METHODS
    private void MoveBackward()
    {
        rb.MovePosition(transform.position + Vector3.back * Time.deltaTime*speed);
    }
    private bool CompareDist()
    {
        if (transform.position.z < dieDistZ)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
    #endregion
}
