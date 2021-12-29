using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private bool isDemoMovementation;
	[SerializeField] private float playerVelocity;

	private Animator animator;

	private PlayerMovementation playerMovementation;
	private PlayerStatus playerStatus;

	private void Awake()
	{
		animator = GetComponent<Animator>();

		if (isDemoMovementation) playerMovementation = new PlayerDemoInput();
		else playerMovementation = new PlayerInput();

		playerStatus = new PlayerStatus();
	}

	public float GetVelocity()
	{
		return this.playerVelocity;
	}

    void Update()
    {
		playerStatus.Update(animator);
		playerMovementation.Update(this, playerStatus);

	}
}
