using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
	[SerializeField] RawImage deathImage;
	Color32 deathImageColor;
	
	public static bool dead = false;
	private int deathImageFade = 1500;
	public bool canDie = true;
	private float deathTime = 0.9f;
	
	void Awake()
	{
		deathImage.enabled = false;
		deathImageColor = new Color32(255, 255, 255, 255);

        Time.timeScale = 1f;
        dead = false;
	}

    private void Start()
    {
        Time.timeScale = 1f;
        dead = false;
    }

    void Update()
	{
		if (canDie)
		{
			if (transform.position.y < -3)  // check if player falls off platform
				Dead(deathTime - 0.2f);
			
			if (ColonelSanders.z > transform.position.z)  // check if colonel sanders is further than player
				Dead(deathTime);
			
			// fade death screen
			if (dead)
			{
				if (deathImageColor.a >= 1)
				{
					if (deathImageColor.a - (byte)(deathImageFade * Time.deltaTime) > 0)
						deathImageColor.a -= (byte)(deathImageFade * Time.deltaTime);
					else
						deathImageColor.a = 0;
				}

				deathImage.color = deathImageColor;
			}
		}
	}
	
    void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Enemy") && canDie)  // detects if player collides with the side of an enemy
			Dead(deathTime);
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Lava Platform") && canDie)  // lava platform
			Dead(deathTime);
	}
	
	public void Dead(float time)  // level will reset in (time) seconds (not accounting for slow down)
	{
		if (!dead)
		{
			deathImage.enabled = true;

			Time.timeScale = 0.6f;
			StartCoroutine(Reset(time));
			
			dead = true;
		}
	}
	
	IEnumerator Reset(float time)  // reset level after two seconds
	{
		yield return new WaitForSeconds(time);
		dead = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
