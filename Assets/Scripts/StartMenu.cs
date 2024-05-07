using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Analytics;

public class StartMenu : MonoBehaviour
{
	[SerializeField] TMP_Text lvlsText;
	[SerializeField] GameObject lvls;
	[SerializeField] MenuOptions levelsDropdown;
	[SerializeField] TMP_Text themeTxt;

    [SerializeField] Texture[] themeImgs = new Texture[12];
    [SerializeField] RawImage themeImg;

	public int lvl;
	private bool lvlsOpen = false;

    private int theme = 1;

	void Start()
	{
		StreamReader reader = new StreamReader("save.dat");
        lvl = int.Parse(reader.ReadToEnd());
        reader.Close();

        ChangeTheme();

        int i = 0;
        foreach (Transform child in lvls.transform)
        {
            i++;

            if (i > lvl)
            {
                child.GetChild(0).GetComponent<MenuOptions>().disabled = true;  // disable italics when mouse hovers over level
                child.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void NewGame()
	{
		SceneManager.LoadScene("Level1");

        StreamWriter writer = new StreamWriter("save.dat");
        writer.Write("1");
        writer.Close();
    }
	
	public void Levels()
	{
		// open and close levels dropdown
		if (!lvlsOpen)
		{
            lvlsText.text = "- Levels >";
			levelsDropdown.msg = "Levels >";
            lvlsOpen = true;
			lvls.SetActive(true);
		}
        else
        {
			lvlsText.text = "- Levels <";
            levelsDropdown.msg = "Levels <";
            lvlsOpen = false;
            lvls.SetActive(false);
        }
	}

	public void Level1()
	{
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6()
    {
        SceneManager.LoadScene(6);
    }

    public void Level7()
    {
        SceneManager.LoadScene(7);
    }

    public void Exit()
	{
		Application.Quit();
	}

    public void ThemeUp()
    {
        if (theme < 12)
            theme++;
        themeTxt.text = theme.ToString();

        ChangeTheme();
    }

    public void ThemeDown()
    {
        if (theme > 1)
            theme--;
        themeTxt.text = theme.ToString();

        ChangeTheme();
    }

    private void ChangeTheme()
    {
        themeImg.texture = themeImgs[theme - 1];

        StreamWriter writer = new StreamWriter("theme.dat");
        writer.Write(theme - 1);
        writer.Close();
    }
}
