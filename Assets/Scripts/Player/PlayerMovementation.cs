using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementation
{
	protected bool up, right, down, left;

    public virtual void Update(Player player, PlayerStatus playerStatus)
	{
		if (playerStatus.IsGiftMode()) return;

		float diff = player.GetVelocity() * Time.deltaTime;

		if (up) player.transform.position += Vector3.up * diff;
		else if (down) player.transform.position += Vector3.down * diff;

		if (right) player.transform.position += Vector3.right * diff;
		else if (left) player.transform.position += Vector3.left * diff;
	}
}
