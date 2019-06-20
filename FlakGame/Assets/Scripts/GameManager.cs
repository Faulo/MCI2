using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public TextMeshProUGUI scoreText;

	private int score;
	
	
	// Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
		{
			FirstInit();
		}else
		{
			Destroy(this);
		}
    }

	private void FirstInit()
	{
		instance = this;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void AddScore (int value)
	{
		score += value;
		scoreText.text = "Score: " + score;
	}
}
