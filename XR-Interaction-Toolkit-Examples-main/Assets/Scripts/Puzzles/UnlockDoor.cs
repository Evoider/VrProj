using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private GameObject _doorToUnlock;

    public void Unlock()
    {
        _doorToUnlock.transform.rotation = Quaternion.identity;
    }
}