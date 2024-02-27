using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
	[SerializeField] float fallSpeed = 10.0f;
	[SerializeField] float riseSpeed = 10.0f;

	[SerializeField] GameObject bottomWaypoint;
	[SerializeField] GameObject topWaypoint;
	[SerializeField] GameObject objToMove;

	private bool falling = false;
	private bool rising = false;

    void Update()
    {
		// platform falling
        if (falling)
		{
			objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, bottomWaypoint.transform.position, fallSpeed * Time.deltaTime);
			
			if (Vector3.Distance(objToMove.transform.position, bottomWaypoint.transform.position) < 0.1f)
				falling = false;
		}
		
		// platform rising
		if (rising)
		{
			objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, topWaypoint.transform.position, riseSpeed * Time.deltaTime);
			
			if (Vector3.Distance(objToMove.transform.position, topWaypoint.transform.position) < 0.1f)
				rising = false;
		}
    }
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			rising = false;
			falling = true;
			Debug.Log("a");
		}
		Debug.Log("b");
	}
	
	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			rising = true;
			falling = false;
		}
	}
}
