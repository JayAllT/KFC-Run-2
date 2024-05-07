using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Maccas : MonoBehaviour
{
    [SerializeField] public float deathTime;
    [SerializeField] PlayerDeath player;
    [SerializeField] GameObject text;

    [SerializeField] RawImage killImage;
    Color32 killImageColor;
    private int killImageFade = 1500;

    public bool kill = false;  // set to true when spawned in; starts kill sequence
    private bool killed = false;
    private bool maccasKilled = false;
    private bool killPlayer = false;
    private bool actuallyKilled = false;

    void Update()
    {
        if (kill && !killed && !maccasKilled)
        {
            StartCoroutine(PlayerDead());
            killed = true;
        }

        // detecting player kill
        if (kill && Input.GetKeyDown("f") && !maccasKilled && !actuallyKilled && !PlayerDeath.dead)
        {
            killImage.enabled = true;
            maccasKilled = true;
            killImageColor = new Color32(255, 255, 255, 255);
            text.SetActive(false);  // get rid of press f text
        }

        // player kills maccas
        if (maccasKilled)
        {
            if (killImageColor.a >= 1)
            {
                if (killImageColor.a - (byte)(killImageFade * Time.deltaTime) > 0)
                    killImageColor.a -= (byte)(killImageFade * Time.deltaTime);
                else
                    killImageColor.a = 0;
            }
            else
            {
                // reset everything
                kill = false;
                killed = false;
                maccasKilled = false;
                killPlayer = false;
                killImage.enabled = false;
                gameObject.SetActive(false);  // set self as inactive
            }

            killImage.color = killImageColor;
        }


        // kills the player
        if (killPlayer && !maccasKilled && !actuallyKilled)
        {
            actuallyKilled = true;
            player.Dead(0.9f);
        }
    }

    IEnumerator PlayerDead()  // starts death sequence in player death
    {
        yield return new WaitForSeconds(deathTime);

        killPlayer = true;
    }
}
