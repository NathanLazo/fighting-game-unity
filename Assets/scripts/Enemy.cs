using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Enemy variables
    public static float enemyHealth = 1000;
    public float enemyNormalAttack = 10;
    public float enemySpecialAttack = 90;


    public Slider slider;


    void Update()
    {
        slider.value = enemyHealth;
        if (enemyHealth <= 0)
        {
            // SceneLoadManager.NivelCarga("credits");
        }
    }
}
