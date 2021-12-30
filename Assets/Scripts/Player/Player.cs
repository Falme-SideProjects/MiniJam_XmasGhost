using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private bool isDemoMovementation;
	[SerializeField] private float playerVelocity;

	private Animator animator;
	private Rigidbody2D rigidbody;

	private PlayerMovementation playerMovementation;
	private PlayerStatus playerStatus;

	private bool isDead = false;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		rigidbody = GetComponent<Rigidbody2D>();

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
		if(!isDead)
		{
			playerStatus.Update(animator, rigidbody);
			playerMovementation.Update(this, playerStatus);

			if(Input.GetKeyDown(KeyCode.Y))
			{
				//Death
				isDead = true;
				animator.SetTrigger("ToDeath");
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("XmasTree"))
		{
			isDead = true;
			animator.SetTrigger("ToDeath");
		}
	}
}
