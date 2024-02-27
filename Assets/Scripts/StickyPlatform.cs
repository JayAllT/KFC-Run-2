using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)  // stick player to platform
	{
		if (collision.gameObject.CompareTag("Player"))
			collision.gameObject.transform.SetParent(transform);
	}
	
	void OnCollisionExit(Collision collision)  // unstick player from platform
	{
		if (collision.gameObject.CompareTag("Player"))
			collision.gameObject.transform.SetParent(null);
	}
}
