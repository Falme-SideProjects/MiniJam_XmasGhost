using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private bool isDemoMovementation;
	[SerializeField] private float playerVelocity;

	[SerializeField] private CanvasGroup winCanvasGroup;

	private Animator animator;
	private Rigidbody2D rigidbody;

	private PlayerMovementation playerMovementation;
	private PlayerStatus playerStatus;

	private Subject subject;

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

	private void Start()
	{
		subject = FindObjectOfType<Subject>();
		subject.LocateObservables();
		subject.CallEvent(Game_Events.INSTRUCTIONS_MOVE_AROUND);
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
			StartCoroutine(DelayToWin());
		} else if(collision.CompareTag("Radar") && !isDead && !playerStatus.IsGiftMode())
		{
			isDead = true;
			animator.SetTrigger("ToDeath");
			StartCoroutine(DelayToRestart());
		} else if(collision.CompareTag("TutorialGift"))
		{
			subject.CallEvent(Game_Events.INSTRUCTIONS_GHOST_TO_SACK);
		}
	}

	private IEnumerator DelayToRestart()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	private IEnumerator DelayToWin()
	{
		yield return new WaitForSeconds(2f);
		winCanvasGroup.alpha = 1;
	}
}
