using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ������ ���⿡�� �־�ΰ� 
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //Action�� ������ void�� ��ȯ�ؾ� �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool isAttacking {  get;  set; } //��ӹ޴� �������� ���� ����

    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        //TODO :: MAGIC NUMVER ����
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
        OnMoveEvent?.Invoke(direction); //?. ������ ���� ������ ����
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); //?. ������ ���� ������ ����
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}


