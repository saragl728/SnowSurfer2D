using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /* void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } */
    [SerializeField] private ParticleSystem finisParticles;

    //para cuando se llegue a la línea de meta con la bandera
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("!Has ganado un pin!");
            //efecto partículas
            finisParticles.Play();
            //espera 1,5 segundos para recargar la escena
            Invoke(nameof(RecargaEscena), 1.5f);
        }
    }

    /// <summary>
    /// Recarga la escena tras un retraso
    /// </summary>
    void RecargaEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
