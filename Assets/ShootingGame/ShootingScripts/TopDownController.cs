using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//공통적인 내용을 여기에서 넣어두고 
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //Action은 무조건 void만 반환해야 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool isAttacking {  get;  set; } //상속받는 곳에서만 수정 가능

    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        //TODO :: MAGIC NUMVER 수정
        if(timeSinceLastAttack <0.2f)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(isAttacking && timeSinceLastAttack>=0.2f)
        { 
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); //?. 없으면 말고 있으면 실행
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); //?. 없으면 말고 있으면 실행
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}


