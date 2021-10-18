using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
  public Animator animator;
  public void IdleRunAnimTransition()
  {
    animator.SetBool("Moving", true);
  }

  public void RunIdleAnimTransition()
  {
    animator.SetBool("Moving", false);
  }

  public void IdleShootAnimTransition()
  {
    animator.SetBool("Shooting", true);
  }


  public void ShootIdleAnimTransition()
  {
    animator.SetBool("Shooting", false);
  }
}
