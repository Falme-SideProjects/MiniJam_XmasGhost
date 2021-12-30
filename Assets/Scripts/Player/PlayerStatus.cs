using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
	private bool isGiftMode = false;

    public void Update(Animator animator, Rigidbody2D rigidbody)
    {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.K))
		{
			if (isGiftMode)
			{
				ChangeToGhost(animator, rigidbody);
			}
			else
			{
				ChangeToGift(animator, rigidbody);
			}
		}

	}

	private void ChangeToGhost(Animator animator, Rigidbody2D rigidbody)
	{
		animator.SetTrigger("toGhost");
		isGiftMode = false;
		rigidbody.gravityScale = 0;
		rigidbody.velocity = Vector2.zero;
	}
	public void ChangeToGift(Animator animator, Rigidbody2D rigidbody)
	{
		animator.SetTrigger("toGift");
		isGiftMode = true;
		rigidbody.gravityScale = 1;
	}

	public bool IsGiftMode()
	{
		return this.isGiftMode;
	}
}
