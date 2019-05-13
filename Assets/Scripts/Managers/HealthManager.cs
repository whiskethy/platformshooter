using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class HealthManager : MonoBehaviour
{
    public GameObject player;
    public int playerHealth;

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        healthText.text = "Health: " + playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(int inDamage)
    {
        playerHealth -= inDamage;
        healthText.text = "Health: " + playerHealth;

        if(playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}
