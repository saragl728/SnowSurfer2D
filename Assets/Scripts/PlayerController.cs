using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    Vector2 moveValue;
    Rigidbody2D rb;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.x > 0)
        {
            Debug.Log("Me muevo a la derecha");
            rb.AddTorque(5f);
        }
        else if (moveValue.x < 0)
        {
            Debug.Log("Me muevo a la izquierda");
            rb.AddTorque(-5f);
        }
    }
}
