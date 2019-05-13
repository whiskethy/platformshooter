using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
	
	private TextMeshProUGUI objectiveText1;
	private TextMeshProUGUI objectiveText2;
	private int enemiesRemaining;
	private int fetchItemsRemaining;

	private LevelExit levelExit;
	public GameObject enemyGroup;
	public int enemyKilledThreshold = 0;
	public GameObject itemGroup;
	public int fetchItemThreshold = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        levelExit = FindObjectOfType<LevelExit>();
		levelExit.gameObject.SetActive(false);

		objectiveText1 = GameObject.FindGameObjectWithTag("ObjectiveCounter1").GetComponent<TextMeshProUGUI>();
		objectiveText2 = GameObject.FindGameObjectWithTag("Objective Counter 2").GetComponent<TextMeshProUGUI>();
 		
		if(enemyGroup != null)
		{
			enemiesRemaining = enemyGroup.transform.childCount;
		}
		else
		{
			enemiesRemaining = 0;
		}
	
		if(itemGroup != null)
		{
			fetchItemsRemaining = itemGroup.transform.childCount;
		}
		else
		{
			fetchItemsRemaining = 0;
		}
		
		UpdateEnemiesCounter(enemiesRemaining);
		UpdateItemCounter(fetchItemsRemaining);
		
    }

   public void KillEnemy()
	{
		enemiesRemaining -=1;
		UpdateEnemiesCounter(enemiesRemaining);
		CheckIfObjectivesComplete();
	}

	public void GetFetchItem()
	{
		fetchItemsRemaining -=1;
		UpdateItemCounter(fetchItemsRemaining);
		CheckIfObjectivesComplete();
	}

	private void CheckIfObjectivesComplete()
	{
		if(enemiesRemaining <= enemyKilledThreshold && fetchItemsRemaining <= fetchItemThreshold)
		{
			levelExit.gameObject.SetActive(true);
		}
	}

	public void UpdateEnemiesCounter(int inCount)
     {
        objectiveText1.text = "Enemies Remaining: " + inCount;
     }

	 public void UpdateItemCounter(int inCount)
     {
        objectiveText2.text = "Gems Remaining: " + inCount;
     }
}
