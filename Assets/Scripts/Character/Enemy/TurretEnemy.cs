using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : Character
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CheckPlayer();
    }

    private void CheckPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, attackRange);
        if (player != null)
        {
            Debug.Log("Player found");
            if(weapon!=null&&weapon.canFire)
            {
                weapon.Fire(shootpoint, attackRange,isPlayer);
            }
            Vector3 relativePos = player.transform.position - transform.position;
            transform.up = relativePos.normalized;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(shootpoint.position, attackRange);
    }
}
