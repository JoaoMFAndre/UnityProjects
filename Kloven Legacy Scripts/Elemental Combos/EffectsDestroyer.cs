using UnityEngine;

public class EffectsDestroyer : MonoBehaviour
{
    public float EffectTimer;

    void Update()
    {
        EffectTimer -= Time.deltaTime;
        if (EffectTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
