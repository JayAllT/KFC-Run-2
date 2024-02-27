using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
	[SerializeField] GameObject[] waypoints;
	[SerializeField] GameObject objToMove;
	
	private int currentWaypoint = 0;

    void Update()
    {
        if (Vector3.Distance(objToMove.transform.position, waypoints[currentWaypoint].transform.position) < 0.1f)
			currentWaypoint = currentWaypoint < waypoints.Length - 1 ? currentWaypoint + 1 : 0;

		objToMove.transform.position = Vector3.MoveTowards(objToMove.transform.position, waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);
    }
}
