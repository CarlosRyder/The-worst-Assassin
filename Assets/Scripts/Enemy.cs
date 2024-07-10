using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int routine;
    public float chronometer;
    public Animator ani;
    public Quaternion angle;
    public float degrees;
    public bool attacking;

    public GameObject target;
    public EnemyRange range;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        EnemyBehavior();
    }
    public void EnemyBehavior() 
    {
        if(Vector3.Distance(transform.position, target.transform.position) > 10) 
        {
            ani.SetBool("run", false);
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                routine = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (routine)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    degrees = Random.Range(0, 360);
                    angle = Quaternion.Euler(0, degrees, 0);
                    routine++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;

            }
        }
        else 
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking)
            {

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                ani.SetBool("walk", false);

                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 3 * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else 
            {
                if(!attacking)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                    ani.SetBool("walk", false);
                    ani.SetBool("run", false);
                }

            }
        }
    }

    public void FinalAnimation() 
    {
        ani.SetBool("attack", false);
        attacking = false;
        range.GetComponent<BoxCollider>().enabled = true;
    }
}
