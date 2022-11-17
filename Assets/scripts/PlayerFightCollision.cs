using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightCollision : MonoBehaviour
{

    public bool isPunching = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPunching = true;
        }
        else
        {
            isPunching = false;
        }
    }

    void MakeDamage(int damage)
    {
        Debug.Log("Player did " + damage + " damage");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy" && isPunching)
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
