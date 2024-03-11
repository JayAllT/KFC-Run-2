using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikes : MonoBehaviour
{
    private float yLvl = 0;
    private float intLvl = 0;  // intermediate y level when sinking spikes
    private float sinkLvl = 1;
    private bool hidden = false;
    private bool hide = true;
    private bool rise = false;

    public float hiddenTime = 2;
    public float visibleTime = 2;
    public float sinkSpeed = 3;
    public bool startHidden = false;

    [SerializeField] Transform spikeOne;
    [SerializeField] Transform spikeTwo;
    [SerializeField] Transform spikeThree;

    void Start()
    {
        yLvl = spikeOne.transform.position.y;
        intLvl = yLvl;

        hidden = startHidden;
        hide = !startHidden;

        // put spikes in starting spot
        if (startHidden)
        {
            spikeOne.transform.position = new Vector3(spikeOne.transform.position.x, yLvl - sinkLvl, spikeOne.transform.position.z);
            spikeTwo.transform.position = new Vector3(spikeTwo.transform.position.x, yLvl - sinkLvl, spikeTwo.transform.position.z);
            spikeThree.transform.position = new Vector3(spikeThree.transform.position.x, yLvl - sinkLvl, spikeThree.transform.position.z);
        }
    }

    void Update()
    {
        if (hide)
        {
            // sink spikes
            intLvl -= sinkSpeed * Time.deltaTime;
            spikeOne.transform.position = new Vector3(spikeOne.transform.position.x, intLvl, spikeOne.transform.position.z);
            spikeTwo.transform.position = new Vector3(spikeTwo.transform.position.x, intLvl, spikeTwo.transform.position.z);
            spikeThree.transform.position = new Vector3(spikeThree.transform.position.x, intLvl, spikeThree.transform.position.z);

            // stop once reached sink depth
            if (yLvl - intLvl >= sinkLvl)
            {
                hide = false;
                hidden = true;
                intLvl = yLvl;
            }
        }
        else if (hidden)
        {
            hidden = false;  // only run wait function once
            StartCoroutine(WaitToShow());
        }
        else if (rise)
        {
            spikeOne.transform.position = new Vector3(spikeOne.transform.position.x, yLvl, spikeOne.transform.position.z);
            spikeTwo.transform.position = new Vector3(spikeTwo.transform.position.x, yLvl, spikeTwo.transform.position.z);
            spikeThree.transform.position = new Vector3(spikeThree.transform.position.x, yLvl, spikeThree.transform.position.z);

            rise = false;
            StartCoroutine(WaitToHide());
        }
    }

    IEnumerator WaitToShow()
    {
        yield return new WaitForSeconds(hiddenTime);

        // start rising spikes
        rise = true;
    }

    IEnumerator WaitToHide()
    {
        yield return new WaitForSeconds(visibleTime);

        // start hiding spikes
        hide = true;
    }
}


