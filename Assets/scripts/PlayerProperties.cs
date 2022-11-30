using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    // Player variables
    public float playerHealth = 100;
    float playerNormalAttack = 20;
    float playerSpecialAttack = 35;

    public GameObject enemy;

    public bool isTouchingTheEnemy;



    void FixedUpdate()
    {
        SetAttack();
    }

    void SetAttack()
    {
        if (isTouchingTheEnemy && ThirdPersonController.isPunching)
        {
            StartCoroutine(MonsterDamage(enemy));
            Enemy.enemyHealth = Enemy.enemyHealth - playerNormalAttack;
            ThirdPersonController.isPunching = false;
        }
        if (isTouchingTheEnemy && ThirdPersonController.isPunchingSpecialAttack && !ThirdPersonController.specialAttackCooldown)
        {
            StartCoroutine(MonsterDamage(enemy));
            Enemy.enemyHealth = Enemy.enemyHealth - playerSpecialAttack;
            ThirdPersonController.isPunchingSpecialAttack = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy")
        {
            isTouchingTheEnemy = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            isTouchingTheEnemy = false;
        }
    }

    IEnumerator MonsterDamage(GameObject monster)
    {
        monster.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.5f);
        monster.GetComponent<Renderer>().material.color = Color.white;
    }
}
