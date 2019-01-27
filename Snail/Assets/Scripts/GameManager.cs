using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	enum GameState { init, run, dead, win }

	[SerializeField]
	private float maxTime = 180.0f;

	[SerializeField]
	private int initialisationSteps = 1;

	[SerializeField]
	private GameObject[] initUI;

	[SerializeField]
	private TextMeshProUGUI clockText;

	[SerializeField]
	private GameObject clockObject;

	private int initCounter = 0;

	private GameState state = GameState.init;

	private float currentTime = 0.0f;

	// Use this for initialization
	void Start ()
	{
		currentTime = maxTime;
		state = GameState.init;

		for (int i = 0; i < initUI.Length; i++)
		{
			initUI[i].SetActive(true);
		}

		clockObject.SetActive(false);

		//state = GameState.run;
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (state)
		{
			case GameState.init:
				break;
			case GameState.run:
				UpdateGameLoop();
				break;
			case GameState.win:
				break;
			case GameState.dead:
				break;
			default:
				break;
		}
	}

	void UpdateGameLoop()
	{
		currentTime -= Time.deltaTime;
		
		var ms = (currentTime % 1.0f).ToString(".00");
		var ss = ((int)(currentTime % 60)).ToString("00");
		var mm = (Mathf.Floor(currentTime / 60) % 60).ToString("00");

		var timeString = mm + "." + ss + ms;

		clockText.text = timeString;
		
		if (currentTime < 0.001f)
		{
			GameOver();
		}
	}

	public bool Initialisation(int initNumber)
	{
		if (initNumber < initCounter)
		{
			return true;
		}
		if (state != GameState.init)
		{
			return false;
		}
		if (initNumber > initCounter)
		{
			return false;
		}
		
		
		initCounter++;
		if (initCounter >= initialisationSteps)
		{
			BeginGame();
		}
		return true;
	}

	void BeginGame()
	{
		clockObject.SetActive(true);
		state = GameState.run;

		for (int i = 0; i < initUI.Length; i++)
		{
			if (initUI[i].activeInHierarchy)
			{
				initUI[i].SetActive(false);
			}
			
		}
	}

	public void GameOver()
	{
		state = GameState.dead;
	}

	public void GameWon()
	{
		state = GameState.win;
		Debug.Log("Won");
	}

	public void Reload ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public bool CanMove()
	{
		return state == GameState.run;
	}
}
