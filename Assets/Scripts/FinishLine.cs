using UnityEngine;

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

    //para cuando se llegue a la línea de meta con la bandera
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Debug.Log("!Has ganado un pin!");
    }
}
