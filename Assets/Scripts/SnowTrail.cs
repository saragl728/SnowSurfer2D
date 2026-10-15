using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem esnouParticles;

    //las partículas aparecen cuando tocas el suelo
    void OnCollisionEnter2D(Collision2D other)
    {
        int layer = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layer)
        {
            esnouParticles.Play();
        }
        
    }
    
    //se van cuando dejas de tocar el suelo
    private void OnCollisionExit2D(Collision2D other) {
        int layer = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layer)
        {
            esnouParticles.Stop();
        }
    }

}
