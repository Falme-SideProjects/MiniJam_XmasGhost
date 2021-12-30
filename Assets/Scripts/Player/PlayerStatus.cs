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
				animator.SetTrigger("toGhost");
				isGiftMode = false;
				rigidbody.gravityScale = 0;
				rigidbody.velocity = Vector2.zero;
			}
			else
			{
				animator.SetTrigger("toGift");
				isGiftMode = true;
				rigidbody.gravityScale = 1;
			}
		}

	}

	public bool IsGiftMode()
	{
		return this.isGiftMode;
	}
}
