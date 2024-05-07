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

	public int difficulty = 0;  // 0 - 3; easy to hard

	public static float z;

	private Rigidbody rb;
	
	void Awake()
	{
		z = transform.position.z;
		scale = transform.localScale;
		rb = GetComponent<Rigidbody>();  // set z velocity of body to speed
    }

	
	void Update()
	{
		rb.velocity = new Vector3(0, 0, speed[difficulty]);

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
