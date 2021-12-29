using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
	private bool isGiftMode = false;

    public void Update(Animator animator)
    {
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.K))
		{
			if (isGiftMode)
			{
				animator.SetTrigger("toGhost");
				isGiftMode = false;
			}
			else
			{
				animator.SetTrigger("toGift");
				isGiftMode = true;
			}
		}

	}

	public bool IsGiftMode()
	{
		return this.isGiftMode;
	}
}
