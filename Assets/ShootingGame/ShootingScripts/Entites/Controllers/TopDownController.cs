using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//공통적인 내용을 여기에서 넣어두고 
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; //Action은 무조건 void만 반환해야 아니면 Func
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackS0> OnAttackEvent;

    protected bool isAttacking {  get;  set; } //상속받는 곳에서만 수정 가능

    private float timeSinceLastAttack = float.MaxValue;

    //protected 프로 퍼티를 한 이유 : 나만 바꾸고 싶지만 가져가는건 내 상속받는 클래스들도 볼 수 있게!
    protected CharacterStatsHandler stats { get;private set; } //TopDownController를 상속하고 있는 애들만 stats필드를 자유롭게 사용할 수 있게 만들어라

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
        OnMoveEvent?.Invoke(direction); //?. 없으면 말고 있으면 실행
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction); //?. 없으면 말고 있으면 실행
    }

    private void CallAttackEvent(AttackS0 attackS0)
    {
        OnAttackEvent?.Invoke(attackS0);
    }
}


