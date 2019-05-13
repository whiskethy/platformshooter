using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
	private AudioManager audioManager;

	
	// Use this for initialization
	void Start () {

		player = FindObjectOfType<Player>().gameObject;

		audioManager = AudioManager.instance;
		if(audioManager == null)
		{
			Debug.Log("No audio manager found in scene!");
		}
		//audioManager.PlaySound("GameMusic");		
	}
	
	public void KillPlayer()
	{
		
	}

	private void LoadDeathScene()
	{

	}

}
