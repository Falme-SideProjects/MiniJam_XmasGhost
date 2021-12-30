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


	public void OnNotify(Game_Events events)
	{
		switch(events)
		{
			case Game_Events.INSTRUCTIONS_SACK_TO_GHOST:
				instructionText.text = instructionSackToGhost.instructionText;
				instructionImage.sprite = instructionSackToGhost.instructionImage;

				instructionText.text = "Press Z or K to change to Ghost Mode";
				break;
			case Game_Events.INSTRUCTIONS_MOVE_AROUND:
				instructionText.text = instructionMoveAround.instructionText;
				instructionImage.sprite = instructionMoveAround.instructionImage;

				instructionText.text = "Press WASD or Arrow Keys to Move Around (Only Ghost Mode)";
				break;
			case Game_Events.INSTRUCTIONS_CHANGE_VISION:
				instructionText.text = instructionChangeVision.instructionText;
				instructionImage.sprite = instructionChangeVision.instructionImage;

				instructionText.text = "Press X or L to Change to Matrix Mode";
				break;
		}
	}


}

[Serializable]
public class InstructionData
{
	public Sprite instructionImage;
	public string instructionText;
}
