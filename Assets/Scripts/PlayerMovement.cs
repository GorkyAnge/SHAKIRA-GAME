using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] public float velocidad; // Velocidad de movimiento del personaje
    [SerializeField] public float poderSalto; // Velocidad de movimiento del personaje
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    
    private BoxCollider2D boxCollider2D;
    private float wallJumpCooldown;
    private float movimientoHorizontal;

    [Header("Animacion")]
    private Animator anim;


    private void Awake()
    {
        // Obtener el componente Rigidbody2D
        body = GetComponent<Rigidbody2D>();
        // Escalar el tamaño del personaje
        transform.localScale = new Vector3(3f, 3f, 3f);
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

        //Flip player when moving
        if(movimientoHorizontal > 0.01f)
            transform.localScale = new Vector3(3, 3, 3);
        else if (movimientoHorizontal < -0.01f)
            transform.localScale = new Vector3(-3, 3, 3);


        //Lógica wall jump
        if (wallJumpCooldown > 0.2)
        {
            // Calcular el vector de movimiento
            body.velocity = new Vector2(movimientoHorizontal * velocidad, body.velocity.y);

            if (OnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = new Vector2(body.velocity.x, 0);

            }
            else
            {
                body.gravityScale = 7;
            }
        }
        else
            wallJumpCooldown += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            Jump();
    }

    private void FlipPlayer()
    {

    }



    private void Jump()
    {
        if (IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, poderSalto);

        }
        else if (OnWall() && !IsGrounded())
        {
            if (movimientoHorizontal == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y,transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
            

        }

    }


    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return movimientoHorizontal == 0 && IsGrounded();
    }


}
