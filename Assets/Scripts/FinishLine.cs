using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private float rotSpeed = 50;
    private float rot = 0;

    void Update()
    {
        rot += rotSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(rot, -90, -90));
    }
}
