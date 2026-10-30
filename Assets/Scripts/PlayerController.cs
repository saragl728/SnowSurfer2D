using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
    /// <summary>
    /// rotación que se aplica
    /// </summary>
    const float TORQUE = 5f;
    /// <summary>
    /// rotación máxima
    /// </summary>
    const float TORQUE_MAX = 500f;

    [Header("Player Movement Settings")]
    [SerializeField] private float boostMulti = 20f;   //multiplicador de velocidad
    [SerializeField] private float baseSpd = 12f;   //velocidad base
    [Header("Score Manager")]
    [SerializeField] private ScoreManager scoreManager;
    [Header("Pause Menu")]
    [SerializeField] private GameObject pauseMenuPanel;

    InputAction moveAction;
    Vector2 moveValue;
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEfector2d;

    int contadorVueltas;
    float totalRotation;
    float previousRotation;

    /// <summary>
    /// dice si el juego está pausado o no
    /// </summary>
    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //pone el sprite del personaje seleccionado
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        transform.GetChild(0).GetChild(selectedCharacter).gameObject.SetActive(true);

        //movimiento
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEfector2d = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //comprueba si le has dado al escape
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }

        RotarJugador();
        ImpulsarJugador();
        CalculateFlips();
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    void RotarJugador()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.x > 0)
        {
            rb.AddTorque(-TORQUE);
            if (rb.angularVelocity < -TORQUE_MAX)
            {
                rb.angularVelocity = -TORQUE_MAX;
            }
        }
        else if (moveValue.x < 0)
        {
            rb.AddTorque(TORQUE);
            if (rb.angularVelocity > TORQUE_MAX)
            {
                rb.angularVelocity = TORQUE_MAX;
            }
        }
    }

    /// <summary>
    /// Acelera al jugador si le da a la tecla de arriba. reinicia la velocidad si le da a abajo
    /// </summary>
    void ImpulsarJugador()
    {
        if (moveValue.y > 0)
        {
            surfaceEfector2d.speed = boostMulti;
            Debug.Log("!Arre!");
        }
        else
        {
            surfaceEfector2d.speed = baseSpd;
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;   //rotación actual
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (Mathf.Abs(totalRotation) >= 340f)
        {
            contadorVueltas++;
            totalRotation = 0;
            Debug.Log("Volteretas: " + contadorVueltas);
            scoreManager.UpdateScore(contadorVueltas * 100);    //actualizo la puntuación en función del nº de vueltas
        }
        previousRotation = currentRotation;

    }
}
