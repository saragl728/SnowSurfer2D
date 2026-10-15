using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;


    /// <summary>
    /// Actualiza la visualización de la puntuación con la puntuación dada
    /// </summary>
    /// <param name="score">Puntuación actual</param> 
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("00000");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
