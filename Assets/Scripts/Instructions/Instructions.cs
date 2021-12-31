using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Instructions : MonoBehaviour, IObservable
{
	[SerializeField] private TextMeshProUGUI instructionText;
	[SerializeField] private Image instructionImage;

	[Header("Instructions Data")]
	[SerializeField] private InstructionData instructionSackToGhost;
	[SerializeField] private InstructionData instructionMoveAround;
	[SerializeField] private InstructionData instructionChangeVision;

	private CanvasGroup canvasGroup;
	private Coroutine delayHideRoutine;

	private List<Game_Events> calledEvents;

	private void Awake()
	{
		calledEvents = new List<Game_Events>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnNotify(Game_Events events)
	{
		if (calledEvents.Contains(events)) return;

		switch(events)
		{
			case Game_Events.INSTRUCTIONS_GHOST_TO_SACK:
				instructionText.text = instructionSackToGhost.instructionText;
				instructionImage.sprite = instructionSackToGhost.instructionImage;
				canvasGroup.alpha = 1;

				break;
			case Game_Events.INSTRUCTIONS_MOVE_AROUND:
				instructionText.text = instructionMoveAround.instructionText;
				instructionImage.sprite = instructionMoveAround.instructionImage;
				canvasGroup.alpha = 1;

				break;
			case Game_Events.INSTRUCTIONS_CHANGE_VISION:
				instructionText.text = instructionChangeVision.instructionText;
				instructionImage.sprite = instructionChangeVision.instructionImage;
				canvasGroup.alpha = 1;

				break;
		}

		calledEvents.Add(events);

		if (delayHideRoutine != null) StopCoroutine(delayHideRoutine);
		delayHideRoutine = StartCoroutine(DelayToHideInstructions());
	}

	private IEnumerator DelayToHideInstructions()
	{
		yield return new WaitForSeconds(3f);
		canvasGroup.alpha = 0;
	}

}

[Serializable]
public class InstructionData
{
	public Sprite instructionImage;
	public string instructionText;
}
