using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
	[SerializeField] private GameObject HowToPlay;
	[SerializeField] private GameObject About;
	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void ShowHowToPlayPanel()
	{
		HowToPlay.SetActive(true);
	}

	public void HideHowToPlayPanel()
	{
		HowToPlay.SetActive(false);
	}

	public void ShowAboutPanel()
	{
		About.SetActive(true);
	}

	public void HideAboutPanel()
	{
		About.SetActive(false);
	}

	public void OpenYoutubeURL()
	{
		Application.OpenURL("https://www.youtube.com/channel/UCe5SC8dmcI5yk3I0RcnaOXQ");
		Debug.Log("yt channel opened");
	}
}
