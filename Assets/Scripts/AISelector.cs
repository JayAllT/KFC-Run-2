using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AISelector : MonoBehaviour
{
    [SerializeField] TMP_Text maccas;
    [SerializeField] TMP_Text spikes;
    [SerializeField] TMP_Text colonel;

    private int MValue = 10;
    private int SValue = 10;
    private int CValue = 10;

    private void Update()
    {
        maccas.text = MValue.ToString();
        spikes.text = SValue.ToString();
        colonel.text = CValue.ToString();
    }

    public void MUp()
    {
        if (MValue < 20)
            MValue++;
    }

    public void MDown()
    {
        if (MValue > 1)
            MValue--;
    }

    public void SUp()
    {
        if (SValue < 20)
            SValue++;
    }

    public void SDown()
    {
        if (SValue > 1)
            SValue--;
    }

    public void CUp()
    {
        if (CValue < 20)
            CValue++;
    }

    public void CDown()
    {
        if (CValue > 1)
            CValue--;
    }

    public void Play()
    {
        StreamWriter writer = new StreamWriter("ai.dat");
        writer.Write($"{MValue}\n{SValue}\n{CValue}");
        writer.Close();

        SceneManager.LoadScene("Level7");
    }
}
