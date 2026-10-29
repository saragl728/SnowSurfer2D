using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] private ParticleSystem muertiPartic;
    [SerializeField] private TextMeshProUGUI mensajeText;
    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = LayerMask.NameToLayer("Floor");

        if (other.gameObject.layer == layer)
        {
            //partículas
            muertiPartic.Play();

            mensajeText.color = Color.red;
            mensajeText.text = "Has fallado";
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
