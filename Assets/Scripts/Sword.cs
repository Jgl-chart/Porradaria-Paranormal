using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public Animator anim;
    public bool canAttack = true;
    public float AttackCooldown = 1.0f;
    public bool isAttacking = false;

    public int DamageDiceNumber = 1;
    public int DamageDice = 10;
    public int Soma = 0;

    private float Damage = 5;
    public float ImpactForce = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                Damage = GameManager.RollDanoDice(DamageDiceNumber, DamageDice, Soma);
                Attack();
            }
        }
    }

    void Attack()
    {
        canAttack = false;
        isAttacking = true;
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        canAttack = true;
        isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isAttacking && other.tag == "Hitable")
        {
            other.GetComponent<Target>().TakeDamage(Damage);
            if(other.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(transform.forward * ImpactForce);
            }
        }
    }

}
