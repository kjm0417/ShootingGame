using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    //실제 이동이 일어날 컴포넌트
    private TopDownController controller;
    private Rigidbody2D movementRb;

    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        //Awake는 주로 내 컴포넌트 안에서 끝나는 거

        movementRb = GetComponent<Rigidbody2D>(); 
        controller = GetComponent<TopDownController>();
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
    }

    private void ApplyMovement(Vector2 direction) 
    {
        direction = direction * 5;
        movementRb.velocity = direction;
    }
}

