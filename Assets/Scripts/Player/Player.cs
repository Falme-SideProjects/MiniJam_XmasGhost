using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private bool isDemoMovementation;
	[SerializeField] private float playerVelocity;

	private Animator animator;
	private Rigidbody2D rigidbody;

	private PlayerMovementation playerMovementation;
	private PlayerStatus playerStatus;

	private bool isDead = false;
	private bool isDone = false;

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
		if(!isDead && !isDone)
		{
			playerStatus.Update(animator, rigidbody);
			playerMovementation.Update(this, playerStatus);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("XmasTree"))
		{
			isDone = true;
			playerStatus.ChangeToGift(animator, rigidbody);
		} else if(collision.CompareTag("Radar") && !isDead && !playerStatus.IsGiftMode())
		{
			isDead = true;
			animator.SetTrigger("ToDeath");
			StartCoroutine(DelayToRestart());
		}
	}

	private IEnumerator DelayToRestart()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
