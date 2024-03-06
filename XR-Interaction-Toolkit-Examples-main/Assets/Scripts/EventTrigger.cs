using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private ThrowEffect _event;

    private void OnTriggerEnter(Collider other)
    {
        //_event.Activate();
    }
}