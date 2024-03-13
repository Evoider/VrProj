using System.Collections;
using UnityEngine;

public class FadeOutHUD : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    private void Awake()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(10);
        _animation.Play();
        yield return new WaitForSeconds(_animation.clip.length);
        Destroy(gameObject);
    }
}