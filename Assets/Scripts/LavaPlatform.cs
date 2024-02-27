using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlatform : MonoBehaviour
{
    [SerializeField] private Material coolMaterial;
	[SerializeField] private Material lavaMaterial;
	
	[SerializeField] private MeshRenderer platformRenderer;
	[SerializeField] private BoxCollider boxCollider;
	
	private float switchTime = 1.1f;
	private float timer = 0.0f;
	public bool lava = true;
	
	void Update()
	{
		boxCollider.enabled = true;  // trigger player collision detection after platform is turned to lava

		// timer
		timer += Time.deltaTime;

		if (timer >= switchTime)
		{
			lava = !lava;

			timer = 0.0f;

			if (lava)
				boxCollider.enabled = false;  // trigger player collision detection when platform is turned to lava
		}

		// update material
		if (lava)
		{
			platformRenderer.material = lavaMaterial;
			platformRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
			platformRenderer.receiveShadows = false;
			tag = "Lava Platform";
		}
		
		else
		{
			platformRenderer.material = coolMaterial;
			platformRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
			platformRenderer.receiveShadows = true;
			tag = "Untagged";
		}
	}
}
