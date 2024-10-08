using System;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField] private Transform projectileSpawnPosition; //총알 생성 위치
    private Vector2 aimDirection = Vector2.right;

    public GameObject TestPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>(); 
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot; //슛을 구독한다

        controller.OnLookEvent += OnAim; //aim 구독
    }

    private void OnAim(Vector2 direction)
    {
        aimDirection = direction;
    }

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        //TODO :: 날아가질 않기 때무에 날아가게 만들 것임
        Instantiate(TestPrefab, projectileSpawnPosition.position, Quaternion.identity); //TestPrefab을 projectileSpawnPosition에서 소환
    }
}


