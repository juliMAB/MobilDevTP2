using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] GameObject player;

    public UnityEngine.Events.UnityAction onPlayerPickup;

    public void MyStart(UnityEngine.Events.UnityAction onPlayerPickup) => this.onPlayerPickup = onPlayerPickup;
    private void OnTriggerEnter(Collider other)
    {
        if (player == other.gameObject)
            onPlayerPickup?.Invoke();
    }
}
