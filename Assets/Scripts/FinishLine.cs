using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    [SerializeField] private TextMeshProUGUI mensajeText;

    //para cuando se llegue a la línea de meta con la bandera
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            mensajeText.color = Color.green;
            mensajeText.text = "Has ganado";
            
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
