using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main; // MainCamera태그붙어있는 카메라를 가져온다
    }

    public void OnMove(InputValue value) //매개변수에서 플레이어가 입력한 값을 가지고 있음
    {
        Vector2 moveInput = value.Get<Vector2>().normalized; //매개변수 value로부터 입력 값을 Vector2 타입으로 가져옴
        CallMoveEvent(moveInput);
        //실제 움직이는 처리는 여기서하는게 아니라 PlayerMovment에서 함
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim); //카메라의 범위를 월드좌표로 변환 해준다
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value)
    {
        isAttacking = value.isPressed; //누르고 있는지 bool값으로 넘겨줌
    }
}

