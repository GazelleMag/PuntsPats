using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float movementSpeed = 5f;
  public Rigidbody2D playerRb;
  public Camera camera;
  Vector2 movement;
  Vector2 mousePos;
  public Animator animator;

  // Update is called once per frame
  void Update()
  {
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

		IdleRunAnimTransition(movement.x, movement.y);

    mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
  }

  void FixedUpdate()
  {
    playerRb.MovePosition(playerRb.position + movement * movementSpeed * Time.fixedDeltaTime);

    Vector2 lookDirection = mousePos - playerRb.position;
    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
    playerRb.rotation = angle;
  }

  void IdleRunAnimTransition(float movementX, float movementY)
  {
			if (movementX != 0 || movementY != 0)
			{
				animator.SetBool("Moving", true);
			}
			else
			{
				animator.SetBool("Moving", false);
			}
  }
}
