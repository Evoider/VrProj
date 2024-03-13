using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _keyPrefab;

    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Spawn()
    {
        Instantiate(_keyPrefab, transform.position, Quaternion.identity);
    }
}