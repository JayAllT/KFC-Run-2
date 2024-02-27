using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{
    [SerializeField] bool hidePlayer = false;
	[SerializeField] PlayerDeath deathScript;
	[SerializeField] Rigidbody body;
	[SerializeField] Camera cam;
	
	void Start()
	{
		if (hidePlayer)
		{
			transform.position = new Vector3(0.0f, 1.3f, -250.0f);
			body.useGravity = false;
			deathScript.canDie = false;
			cam.enabled = false;
		}
	}
}
