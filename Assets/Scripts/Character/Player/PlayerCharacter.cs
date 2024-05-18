using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    [SerializeField]
    float offset;
    [SerializeField]
    Rigidbody2D rigidbody;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float dashCoolDown;
    [SerializeField]
    float dashTime;

    float horizontalMovement;
    float verticalMovement;
    Vector2 movement;

    bool canMove=true;
    bool canDash = true;
    bool isDashing = false;

    void Start()
    {
        isPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }


    void FixedUpdate()
    {
        if (canMove&&!isDashing)
        {
            MovePlayer();
        }
    }


    private void HandleInput()
    {

        //Movement
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        movement = new Vector2(horizontalMovement, verticalMovement).normalized;
        //Dash
        if(Input.GetMouseButtonDown(1)&&canDash)
        {
            StartCoroutine(Dash());
        }
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire(shootpoint,attackRange,isPlayer);
        }
    }

    private void MovePlayer()
    {
        if(rigidbody != null)
        {
            rigidbody.velocity = new Vector2(movement.x*moveSpeed, movement.y*moveSpeed);  
        }
        if (movement != Vector2.zero)
        {
            float rotation = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotation + offset);
        }
    }
    
    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        rigidbody.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        yield return new WaitForSeconds(dashTime);
        isDashing=false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(shootpoint.position, attackRange);
    }
}
