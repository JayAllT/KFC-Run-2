using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
	string save = "save.dat";

	void Start()
	{
		Cursor.visible = false;
	}

    void Update()
    {
        if (transform.position.z > 660)
		{
			// write to save file
			StreamWriter writer = new StreamWriter(save);
			writer.WriteLine((SceneManager.GetActiveScene().buildIndex + 1).ToString());
			writer.Close();
			
			// load next level
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		
		// closes game if user presses escape
		if (Input.GetKey("escape"))
			Application.Quit();
    }
}
