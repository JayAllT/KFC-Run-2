using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
	[SerializeField] TMP_Text text;

	void Start()
	{
		StreamReader reader = new StreamReader("save.dat");
		text.text = "Continue - " + reader.ReadToEnd();
		reader.Close();
	}

    public void NewGame()
	{
		SceneManager.LoadScene("Level1");
	}
	
	public void Continue()
	{	
		StreamReader reader = new StreamReader("save.dat");
		SceneManager.LoadScene(int.Parse(reader.ReadToEnd()));
		reader.Close();
	}
	
	public void Exit()
	{
		Application.Quit();
	}
}
