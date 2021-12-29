using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemoInput : PlayerMovementation
{
	private float currentTime = 0;

	public override void Update(Player player, PlayerStatus playerStatus)
	{
		currentTime += Time.deltaTime;

		if (currentTime > 4f)
		{
			Reset();
		}
		else if (currentTime > 3f)
		{
			up = false;
			down = true;
		}
		else if (currentTime > 2f)
		{
			right = true;
		}
		else if(currentTime > 1f)
		{
			up = true;
		}

		base.Update(player, playerStatus);
	}

	private void Reset()
	{
		up = right = down = left = false;
		currentTime = 0f;
	}
}
