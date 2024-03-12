using TMPro;
using UnityEngine;

public class SwitchLamp_SetKanji : MonoBehaviour
{
    [SerializeField] int _id;
    [SerializeField] TMP_Text _kanji;

    private string[] _kanjiList;

    private void Awake()
    {
        _kanjiList = new string[5] { "月", "火", "水", "木", "金" };
        SetKanji();
    }

    public void SetKanjiId(int id)
    {
        _id = id;
        SetKanji();
    }

    private void SetKanji()
    {
        _kanji.text = _kanjiList[_id];
    }
}