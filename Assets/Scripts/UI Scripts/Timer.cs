using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float time;
     
    void Start () {
        timeText = GetComponent<TextMeshProUGUI>();

        timeText.text = "Time: " + time.ToString("00.00");

	}

     void Update()
     {
         time += Time.deltaTime;

         timeText.text = "Time:  " + time.ToString("00.00");
     }

}
