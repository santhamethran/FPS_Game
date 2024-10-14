using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoundownScript : MonoBehaviour
{
    public float totalTime = 60f;
    public TMP_Text countdownText;

    private float currentTime;

    private void Start()
    {
        currentTime = totalTime;
        StartCoroutine(Countdown());
    }
   IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");

            yield return new WaitForSeconds(1f);

            currentTime--;
        }

        countdownText.text = "Attack";
        Destroy(countdownText.gameObject, 1);
       
    }
}
