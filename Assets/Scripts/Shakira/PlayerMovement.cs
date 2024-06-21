using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float velocidad; // Velocidad de movimiento del personaje
    [SerializeField] public float poderSalto; // Velocidad de movimiento del personaje
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float coyoteTime = 0.2f; // Duración del coyote time

    private Rigidbody2D body;
    private BoxCollider2D boxCollider2D;
    private float movimientoHorizontal;
    private float coyoteTimeCounter;

    [Header("Animacion")]
    private Animator anim;

    private void Awake()
    {
        // Obtener el componente Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        // Escalar el tamaño del personaje
        transform.localScale = new Vector3(3f, 3f, 0f);
        // Obtener el componente Animator
        anim = GetComponent<Animator>();
        // Obtener el componente BoxCollider2D
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        anim.SetBool("isGrounded", IsGrounded());
    }

    void Update()
    {
        // Obtener la entrada del teclado
        movimientoHorizontal = Input.GetAxis("Horizontal");
        anim.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));

        // Flip player when moving
        if (movimientoHorizontal > 0.01f)
            transform.localScale = new Vector3(3, 3, 0);
        else if (movimientoHorizontal < -0.01f)
            transform.localScale = new Vector3(-3, 3, 0);

        // Calcular el vector de movimiento
        body.velocity = new Vector2(movimientoHorizontal * velocidad, body.velocity.y);

        // Aplicar gravedad normal
        body.gravityScale = 7;

        // Actualizar el coyote time
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // Permitir salto con coyote time
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f)
        {
            Jump();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, poderSalto);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return movimientoHorizontal == 0 && IsGrounded();
    }
}
