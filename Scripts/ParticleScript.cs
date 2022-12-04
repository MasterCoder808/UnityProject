using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem par;

    public void Play()
    {
        par.Play();
    }

    public void Stop()
    {
        par.Stop();
    }
}
