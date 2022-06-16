using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    public GameObject sword;
    bool canAttack = true;
    public float AttackCooldown = 0.5f;
    public float range = 5f;

    public Camera cam;

    private void Update()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            SwordAttack();
        }
    }

    public void SwordAttack()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            {
                // TODO: Play enemy hit sound effect
                hit.transform.GetComponent<EnemyHealth>().DamageEnemy(25);
            }
            else
            {
                // TODO: Play sword clash sound effect

            }
        }
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.Play("SwordAttack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        canAttack = true;
    }
}
