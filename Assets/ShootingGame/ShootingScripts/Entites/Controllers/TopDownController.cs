using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������� ������ ���⿡�� �־�ΰ� 
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //Action�� ������ void�� ��ȯ�ؾ� �ƴϸ� Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackS0> OnAttackEvent;

    protected bool isAttacking {  get;  set; } //��ӹ޴� �������� ���� ����

    private float timeSinceLastAttack = float.MaxValue;

    //protected ���� ��Ƽ�� �� ���� : ���� �ٲٰ� ������ �������°� �� ��ӹ޴� Ŭ�����鵵 �� �� �ְ�!
    protected CharacterStatsHandler stats { get;private set; } //TopDownController�� ����ϰ� �ִ� �ֵ鸸 stats�ʵ带 �����Ӱ� ����� �� �ְ� ������

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if(timeSinceLastAttack <stats.CurrentStat.attackS0.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(isAttacking && timeSinceLastAttack>= stats.CurrentStat.attackS0.delay)
        { 
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackS0);
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

    private void CallAttackEvent(AttackS0 attackS0)
    {
        OnAttackEvent?.Invoke(attackS0);
    }
}


