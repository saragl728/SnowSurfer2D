using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float boostMulti = 20f;   //multiplicador de velocidad
    [SerializeField] private float baseSpd = 15f;   //velocidad base
    InputAction moveAction;
    Vector2 moveValue;
    Rigidbody2D rb;
    SurfaceEffector2D surfaceEfector2d;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
        surfaceEfector2d = FindAnyObjectByType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotarJugador();
    }

    void RotarJugador()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.x > 0)
        {
            rb.AddTorque(5f);
        }
        else if (moveValue.x < 0)
        {
            rb.AddTorque(-5f);
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
        }
        else
        {
            surfaceEfector2d.speed = baseSpd;
        }
    }
}
