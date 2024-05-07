using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaccasImage : MonoBehaviour
{
    void Awake()
    {
        GetComponent<RawImage>().enabled = false;
    }
}
