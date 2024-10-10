using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    //실제 이동이 일어날 컴포넌트
    private TopDownController controller;
    private Rigidbody2D movementRb;
    private CharacterStatsHandler characterStatsHandler;

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {
        //Awake는 주로 내 컴포넌트 안에서 끝나는 거

        movementRb = GetComponent<Rigidbody2D>(); 
        controller = GetComponent<TopDownController>();
        characterStatsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        //물리관련
        //rigidbody2d내용
        ApplyMovement(movementDirection);

        if(knockbackDuration >0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    public void ApplyKnockback(Transform Other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(Other.position - transform.position).normalized*power;
    }

    private void ApplyMovement(Vector2 direction) 
    {
        direction = direction * characterStatsHandler.CurrentStat.speed; 
        movementRb.velocity = direction;

        if(knockbackDuration >0.0f)
        {
            direction += knockback;
        }

        movementRb.velocity = direction;
    }
}
