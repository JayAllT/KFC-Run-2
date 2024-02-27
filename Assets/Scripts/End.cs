using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class End : MonoBehaviour
{
    void Start()
    {
		// write level 1 to save file
		StreamWriter writer = new StreamWriter("save.dat");
		writer.WriteLine("1");
		writer.Close();

		Cursor.visible = false;

		// exit game in 5 seconds
        StartCoroutine(Exit());
    }
	
	IEnumerator Exit()
	{
		yield return new WaitForSeconds(5.0f);
		Application.Quit();
	}
}
