using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private GameObject charge;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float attackCooldownTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && attackCooldownTimer > attackCooldown && playerMovement.CanAttack())
        {
            Attack();
        }
        attackCooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        attackCooldownTimer = 0;

        // Iniciar el delay para instanciar el proyectil
        StartCoroutine(InstantiateProjectileAfterDelay());
    }

    private IEnumerator InstantiateProjectileAfterDelay()
    {
        // Esperar hasta que la animación de ataque termine
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        // Determinar la dirección de disparo basada en la escala del personaje
        Vector3 chargeDirection = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        // Crear el charge y ajustar su rotación
        GameObject newCharge = Instantiate(charge, attackPoint.position, Quaternion.identity);
        newCharge.transform.right = chargeDirection;

        // Destruir el proyectil después de un tiempo definido
        Destroy(newCharge, newCharge.GetComponent<Projectile>().lifeTime);
    }
}
