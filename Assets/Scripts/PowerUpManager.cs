using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.5f;  //por cuánto se aumentará el sprite
    [SerializeField] private float scaleDuracion = 2f;  //tiempo que durará el aumento de tamaño
    [SerializeField] private float animacionDuracion = 0.15f;   //duración de la animación

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(ScalePlayer(other.transform));
        }
    }

    private IEnumerator ScalePlayer(Transform player)
    {
        Vector3 originalScale = player.localScale;
        Vector3 bigScale = originalScale * scaleMultiplier;

        float elapsedTime = 0f;

        while (elapsedTime < animacionDuracion)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / animacionDuracion);

            player.localScale = Vector3.Lerp(originalScale, bigScale, t);

            yield return null;
        }

        player.localScale = bigScale;

        yield return new WaitForSeconds(scaleDuracion);

        elapsedTime = 0f;

        while (elapsedTime < animacionDuracion)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / animacionDuracion);

            player.localScale = Vector3.Lerp(bigScale, originalScale, t);

            yield return null;
        }

        player.localScale = originalScale;
    }
}
