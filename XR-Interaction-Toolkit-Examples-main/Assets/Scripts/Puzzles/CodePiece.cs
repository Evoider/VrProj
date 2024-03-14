using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class CodePiece : MonoBehaviour
{
    [SerializeField] private CodeDisplay _codeDisplay;
    [SerializeField] private TMP_Text _text;

    [Header("Dissolve Effect")]
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _dissolveRate = 0.0125f;
    [SerializeField] private float _refreshRate = 0.025f;
    [SerializeField] private VisualEffect _vfx;

    private char _code;
    private int _index;

    public void InitCode(char code, int index)
    {
        _code = code;
        _index = index;
        _text.text = _code.ToString();
    }

    public void AddToCodeDisplay()
    {
        _codeDisplay.AddCodeDigit(_code, _index);
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve()
    {
        _text.gameObject.SetActive(false);
        _vfx.gameObject.SetActive(true);
        _vfx.Play();
        Destroy(GetComponent<SpawnVariant>().Variant);
        float counter = 0;

        while (_mesh.material.GetFloat("_DissolveAmount") < 1)
        {
            counter += _dissolveRate;
            _mesh.material.SetFloat("_DissolveAmount", counter);
            yield return new WaitForSeconds(_refreshRate);
        }

        Destroy(gameObject);
    }
}