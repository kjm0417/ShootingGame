using System;
using UnityEngine;

public class TopDownAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isHit = Animator.StringToHash("isHit");
    private static readonly int Attack = Animator.StringToHash("attack");

    private readonly float magnituteThreshold = 0.5f; //walking을 하는데 너무 조금 움직이면 멈춘걸로 하고 싶다
    private HealthSystem healthSystem;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        topDownController.OnAttackEvent += Attacking;
        topDownController.OnMoveEvent += Move;

        if(healthSystem != null )
        {
            healthSystem.OnDamage += Hit;
            healthSystem.OnInvincibilityEnd += InvincibilityEnd;
        }
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);
    }

    private void Attacking(AttackS0 s0)
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetBool(isHit, true);
    }

    private void InvincibilityEnd() //무적
    {
        animator.SetBool(isHit, false);
    }
}
