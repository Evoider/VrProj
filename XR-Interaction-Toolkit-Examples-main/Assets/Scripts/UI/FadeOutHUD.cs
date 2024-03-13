using System.Collections;
using UnityEngine;

public class FadeOutHUD : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private AnimationClip _clip;

    private void Awake()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(10);
        _animation.Play(_clip.name);
        yield return new WaitForSeconds(_clip.length);
        Destroy(gameObject);
    }
}