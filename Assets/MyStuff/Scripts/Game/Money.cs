using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    private void OnTriggerEnter(Collider other)
    {
        if ((layerMask & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            DataManager.UpdateMoney(Data.currency + 1);
            Destroy(gameObject);
        }
    }
}
