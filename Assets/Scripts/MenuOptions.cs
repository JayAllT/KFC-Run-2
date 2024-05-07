using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuOptions : MonoBehaviour
{
    TMP_Text text;
    public string msg;

    public bool disabled = false;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        msg = text.text;
    }

    public void MouseEnter()
    {
        if (!disabled)
        {
            text.fontStyle = FontStyles.Italic;
            text.text = $"- {msg}";
        }
    }

    public void MouseLeave()
    {
        if (!disabled)
        {
            text.fontStyle = FontStyles.Normal;
            text.text = msg;
        }
    }
}
