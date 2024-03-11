using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonelSanders : MonoBehaviour
{
	private Vector3 scale;
	
    private float[] speed = new float[] { 15f, 16f, 17, 17.5f };
	private float expand = 0.15f;
	private float rotSpeed = 50f;
	private float rotSpeedIncrease = 20f;
	private float rot = -30f;

	private int difficulty = 0;  // 0 - 3; easy to hard

	public static float z;
	
	void Awake()
	{
		z = transform.position.z;
		scale = transform.localScale;
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed[difficulty]);  // set z velocity of body to speed
	}
	
	void Update()
	{
		z = transform.position.z;
		
		scale.x += expand * Time.deltaTime;
		scale.y += expand * Time.deltaTime;
		scale.z += expand * Time.deltaTime;

		rotSpeed += rotSpeedIncrease * Time.deltaTime;
        rot += rotSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(new Vector3(rot, rot, rot));
		
		transform.localScale = scale;
	}
}
