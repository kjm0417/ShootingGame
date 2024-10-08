using System;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer; //화살 
    [SerializeField] private Transform armPivot; //

    [SerializeField] private SpriteRenderer characterRenderer; //

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //y ,x순으로 받아야 라디안이 나오는데 라디안에서 각도로 바꿔서 전달해주고
        //-180도에서 180도 값만 돌려준다

        characterRenderer.flipX = Mathf.Abs(rotZ)>90f; //Abs는 절대값이다

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ); //받은 각도를 대입
    }
}

