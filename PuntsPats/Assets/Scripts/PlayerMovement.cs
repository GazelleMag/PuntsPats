using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float movementSpeed = 5f;
  public Rigidbody2D playerRb;
  public Camera mainCamera;
  Vector2 movement;
  Vector2 mousePos;
  public PlayerAnimation playerAnimation;

  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    ControlMovementAnimation(movement.x, movement.y);

    mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
  }

  void FixedUpdate()
  {
    playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.fixedDeltaTime);

    Vector2 lookDirection = mousePos - playerRb.position;
    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
    playerRb.rotation = angle;
  }

  void ControlMovementAnimation(float movementX, float movementY)
  {
    if(movementX != 0 || movementY != 0)
    {
      playerAnimation.RunAnimTransition();
    }
    else
    {
      playerAnimation.IdleAnimTransition();
    }
  }
}
