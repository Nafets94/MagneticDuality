using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] effects;

    [SerializeField] private AudioClip metalTouch;
	[SerializeField] private AudioClip magnetHit;

    [SerializeField] private AudioSource sourceLeft;
	[SerializeField] private AudioSource sourceRight;
	[SerializeField] private AudioSource sourceLeftOnHit;
	[SerializeField] private AudioSource sourceRightOnHit;
	[SerializeField] private AudioSource music;

	[SerializeField] private TMPro.TextMeshProUGUI scoreNumber;
	[SerializeField] private TMPro.TextMeshProUGUI gameOverScreenScore;
	float score = 0;
	[SerializeField] private GameObject gameOver;
	[SerializeField] private GameObject gamePaused;

	private void Start()
	{
		PlayLeft();
		PlayRight();
		Time.timeScale = 1;
	}

	public void PlayLeft()
	{
		sourceLeft.clip = metalTouch;
		sourceLeft.mute = false;
		sourceLeft.Play();
	}

	public void StopLeft()
	{
		sourceLeft.mute = true;
	}

	public void PlayRight()
	{
		sourceRight.clip = metalTouch;
		sourceRight.mute = false;
		sourceRight.Play();
	}

	public void StopRight()
	{
		sourceRight.mute = true;
	}

	public void ToggleEffectsLeft(bool b)
	{
		effects[0].gameObject.SetActive(b);
		effects[1].gameObject.SetActive(b);
	}

	public void ToggleEffectsRight(bool b)
	{
		effects[2].gameObject.SetActive(b);
		effects[3].gameObject.SetActive(b);
	}

	public void PlayHitLeft()
	{
		sourceLeftOnHit.clip = magnetHit;
		sourceLeftOnHit.Play();
	}

	public void PlayHitRight()
	{
		sourceRightOnHit.clip = magnetHit;
		sourceRightOnHit.Play();
	}

	private void Update()
	{
		score += Time.deltaTime * 1000;
		scoreNumber.text = ((int)score).ToString();
	}

	public void EndGame()
	{
		StartCoroutine(GameOver());
	}

	private IEnumerator GameOver()
	{
		yield return new WaitForSeconds(2.5f);
		sourceLeft.mute = true;
		sourceRight.mute = true;
		sourceLeftOnHit.mute = true;
		sourceRightOnHit.mute = true;
		music.mute = true;

		// show game over screen
		gameOverScreenScore.text = "Score: "+((int)score).ToString();
		gameOver.SetActive(true);
		Time.timeScale = 0;
	}

	public void ReloadLevel()
	{
		Time.timeScale = 1;
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public void GamePaused()
	{
		Time.timeScale = 0;
		gamePaused.SetActive(true);

		sourceLeft.mute = true;
		sourceRight.mute = true;
		sourceLeftOnHit.mute = true;
		sourceRightOnHit.mute = true;
		music.mute = true;
	}

	public void GameResumed()
	{
		Time.timeScale = 1;
		gamePaused.SetActive(false);

		sourceLeft.mute = false;
		sourceRight.mute = false;
		sourceLeftOnHit.mute = false;
		sourceRightOnHit.mute = false;
		music.mute = false;
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
