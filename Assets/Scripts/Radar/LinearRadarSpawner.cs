using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearRadarSpawner : MonoBehaviour
{
	[SerializeField] private GameObject linearRadarGameObject;
	[SerializeField] private float timeSpan = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(SpawnNewLinearRadar());
    }

    private IEnumerator SpawnNewLinearRadar()
	{
		while(true)
		{
			yield return new WaitForSeconds(timeSpan);
			Instantiate(linearRadarGameObject, transform.position, Quaternion.identity, transform);
		}
	}
}
