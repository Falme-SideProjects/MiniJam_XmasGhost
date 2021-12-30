using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform targetTransform;

    void Update()
    {
        if(targetTransform != null)
		{
			transform.position = 
				new Vector3(
					targetTransform.position.x,
					targetTransform.position.y,
					transform.position.z
					);
		}
    }
}
