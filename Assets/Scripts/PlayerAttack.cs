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
            Attack();
        attackCooldownTimer += Time.deltaTime;

    }
    
    private void Attack()
    {
        anim.SetTrigger("attack");
        attackCooldownTimer = 0;
        Instantiate(charge, attackPoint.position, attackPoint.rotation);



    }

}
