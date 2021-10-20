using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
  public Animator animator;
  public void IdleAnimTransition()
  {
    animator.SetBool("Moving", false);
  }

  public void RunAnimTransition()
  {
    animator.SetBool("Moving", true);
  }

  public void ShootAnimTransition()
  {
    animator.SetTrigger("Shooting");
  }

}
