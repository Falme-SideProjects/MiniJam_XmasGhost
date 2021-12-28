using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
	private List<IObservable> observables;

	private void Awake()
	{
		observables = new List<IObservable>();
	}

	void Start()
    {
		LocateObservables();
    }

	public void CallEvent(Game_Events event_name)
	{
		for(int a=0; a<observables.Count; a++)
		{
			if(observables[a] != null)
				observables[a].OnNotify(event_name);
		}
	}

	private void LocateObservables()
	{
		observables.Add(FindObjectOfType<Instructions>());
	}
}
