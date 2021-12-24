using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float movementSpeed;
  public Rigidbody2D playerRb;
  public Camera mainCamera;
  Vector2 movement;
  Vector2 mousePos;
  Vector2 lookDirection;
  float lookAngle;
  public PlayerAnimation playerAnimation;

  void Start()
  {
    movementSpeed = 4f;
  }

  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    ControlMovementAnimation(movement.x, movement.y);

    mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
  }

  void FixedUpdate()
  {
    MovePlayer();
    RotatePlayerToMouse();
  }

  void ControlMovementAnimation(float movementX, float movementY)
  {
    if (movementX != 0 || movementY != 0)
    {
      playerAnimation.RunAnimTransition();
    }
    else
    {
      playerAnimation.IdleAnimTransition();
    }
  }

  void MovePlayer()
  {
    playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.fixedDeltaTime);
  }

  void RotatePlayerToMouse()
  {
    lookDirection = mousePos - playerRb.position;
    lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
    playerRb.rotation = lookAngle;
  }

}
