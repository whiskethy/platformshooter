using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    public int damageToPlayer = 6;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<GameManager>().GetComponent<HealthManager>().DamagePlayer(damageToPlayer);
        }
    }
}
