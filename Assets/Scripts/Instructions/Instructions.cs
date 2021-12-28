using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instructions : MonoBehaviour, IObservable
{
	[SerializeField] private TextMeshProUGUI instructionText;

	public void OnNotify(Game_Events events)
	{
		switch(events)
		{
			case Game_Events.INSTRUCTIONS_SACK_TO_GHOST:
				instructionText.text = "Press Z or K to change to Ghost Mode";
				break;
			case Game_Events.INSTRUCTIONS_MOVE_AROUND:
				instructionText.text = "Press WASD or Arrow Keys to Move Around (Only Ghost Mode)";
				break;
			case Game_Events.INSTRUCTIONS_CHANGE_VISION:
				instructionText.text = "Press X or L to Change to Matrix Mode";
				break;
		}
	}


}
