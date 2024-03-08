using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class ProgressionSliders : MonoBehaviour
{
    [SerializeField] Slider lvlSlider;
    [SerializeField] Slider colonelSlider;

    [SerializeField] Transform chicken;
    [SerializeField] Transform colonel;

    private int lvlEndPos = 660;

    void Update()
    {
        lvlSlider.value = chicken.position.z / lvlEndPos;
        colonelSlider.value = colonel.position.z / lvlEndPos;
    }
}
