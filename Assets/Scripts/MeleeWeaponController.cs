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
    public AudioSource swingSound;
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
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.Play("SwordAttack");
        StartCoroutine(ResetAttackCooldown());
        swingSound.Play();

        StartCoroutine(attacking());
        
    }

    IEnumerator attacking()
    {
        yield return new WaitForSeconds(0.25f);

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "Enemy")
            {
                hitEnemy.Play();
                hit.transform.GetComponent<EnemyHealth>().DamageEnemy(25);
            }
            else if (hit.transform.tag == "Crate")
            {
                hitOther.Play();
                hit.transform.GetComponent<Crate>().DamageCrate();
            }
            else
            {
                hitOther.Play();
            }
        }
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        canAttack = true;
    }
}
