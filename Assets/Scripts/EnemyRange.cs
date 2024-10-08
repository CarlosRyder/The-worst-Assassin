using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public Animator ani;
    public Enemy enemy;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) 
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemy.attacking = true;
        }
    }
}
