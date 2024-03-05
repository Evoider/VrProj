using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private ThrowObject _event;

    private void OnTriggerEnter(Collider other)
    {
        _event.Activate();
    }
}