using UnityEngine;

public class SpawnVariant : MonoBehaviour
{
    [SerializeField] private GameObject _variantPrefab;

    public GameObject Variant => _variant;
    private GameObject _variant;

    private void Awake()
    {
        _variant = Instantiate(_variantPrefab, transform.position, Quaternion.identity, transform);
    }

    private void Update()
    {
        if (_variant != null) _variant.transform.position = transform.position;
    }

    private void OnDestroy()
    {
        Destroy(_variant);
    }
}