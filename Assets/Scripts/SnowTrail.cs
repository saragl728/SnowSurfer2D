using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem esnouParticles;
    private Animator animator;


    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        animator = transform.GetChild(0).GetChild(selectedCharacter).GetComponent<Animator>();
    }

    //las partículas aparecen cuando tocas el suelo
    void OnCollisionEnter2D(Collision2D other)
    {
        int layer = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layer)
        {
            esnouParticles.Play();
            animator.SetBool("isJumping", false);
        }
        
    }
    
    //se van cuando dejas de tocar el suelo
    private void OnCollisionExit2D(Collision2D other) {
        int layer = LayerMask.NameToLayer("Floor");
        if (other.gameObject.layer == layer)
        {
            esnouParticles.Stop();
            animator.SetBool("isJumping", true);
        }
    }

}
