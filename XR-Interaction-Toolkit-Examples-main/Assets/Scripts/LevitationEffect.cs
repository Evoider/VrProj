using UnityEngine;

public class LevitationEffect : MonoBehaviour
{
    public float levitationHeight = 1.0f;
    public float levitationSpeed = 1.0f;

    private void Awake()
    {
        LevitationTrigger.OnLevitated += SchoolSceneController_OnLevitated;
    }

    private void OnDestroy()
    {
        LevitationTrigger.OnLevitated -= SchoolSceneController_OnLevitated;
    }

    private void SchoolSceneController_OnLevitated()
    {
        Vector3 newPosition = transform.position + new Vector3(0, Mathf.Sin(Time.time * levitationSpeed) * levitationHeight, 0);
        transform.position = newPosition; // Déplace l'objet vers la nouvelle position
    }
}