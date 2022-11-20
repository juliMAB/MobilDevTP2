using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            GameEnd.onEndGame();
            gameObject.SetActive(false);
        }
    }
}
