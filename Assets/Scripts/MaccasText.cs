using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaccasText : MonoBehaviour
{
    private float time = 10f;
    private float timer = 0f;

    private bool red = false;

    private TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        timer += time * Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;

            if (red)
            {
                red = false;
                text.color = Color.red;
            }
            else
            {
                red = true;
                text.color = Color.white;
            }

        }

    }
}
