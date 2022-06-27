using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponController : MonoBehaviour
{
    public GameObject sword;
    bool canAttack = true;
    public float AttackCooldown = 0.5f;
    public float range = 5f;

    [Header("Sounds")]
    public AudioSource swing;
    public AudioSource hitEnemy;
    public AudioSource hitOther;

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
        swing.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            {
                StartCoroutine(playSwordHitEnemySound());
                StartCoroutine(dealDamage(hit));
            }
            else if (hit.transform.tag == "Crate")
            {
                StartCoroutine(playSwordHitOtherSound());
                StartCoroutine(damageCrate(hit));
            }
            else
            {
                StartCoroutine(playSwordHitOtherSound());
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

    IEnumerator dealDamage(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.25f);
        hit.transform.GetComponent<EnemyHealth>().DamageEnemy(25);
    }

    IEnumerator damageCrate(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.25f);
        hit.transform.GetComponent<Crate>().DamageCrate();
    }

    IEnumerator playSwordHitEnemySound()
    {
        yield return new WaitForSeconds(.09f);
        hitEnemy.Play();
    }

    IEnumerator playSwordHitOtherSound()
    {
        yield return new WaitForSeconds(.09f);
        hitOther.Play();
    }
}
