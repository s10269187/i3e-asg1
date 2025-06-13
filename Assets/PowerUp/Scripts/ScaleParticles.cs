using UnityEngine;

public class ScaleParticles : MonoBehaviour
{
    public float scaleMultiplier = 1.5f;

    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            main.startSize = new ParticleSystem.MinMaxCurve(main.startSize.constant * scaleMultiplier);
        }
    }
}
