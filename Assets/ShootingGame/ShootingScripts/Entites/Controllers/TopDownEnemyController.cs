using Unity.VisualScripting;
using UnityEngine;

public class TopDownEnemyController : TopDownController
{
    protected Transform ClosestTarget { get; private set; }

    protected override void Awake()
    {
        base.Awake(); //스탯관련을 일단 받아옴
    }

    protected virtual void Start()
    {
        ClosestTarget = GameManager.Instance.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    protected float DistanceToTarget() //적 방향
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    protected Vector2 DirectionToTarget() //타겟 거리
    {
        return (ClosestTarget.position - transform.position).normalized;
    }

}
