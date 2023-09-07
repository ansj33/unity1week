using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharaterController
{
    // Start is called before the first frame update
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
    
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        //마우스포지션을 월드포지션(마우스의 월드상 포지션)으로 바꿈
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= 0.9f)
        {
            CallLookEvent(newAim);
        }
    }
    
    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }
}
