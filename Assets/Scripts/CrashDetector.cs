using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

        [SerializeField] private ParticleSystem muertiPartic;
    void OnTriggerEnter2D(Collider2D other)
    {
        int layer = LayerMask.NameToLayer("Floor");

        if (other.gameObject.layer == layer)
        {
            //partículas
            muertiPartic.Play();

            Debug.Log("Has palmado");
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
