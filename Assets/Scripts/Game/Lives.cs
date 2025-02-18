using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_error;
    [SerializeField] int totalLive = 3;
    int lives = 0;
    int error_number = 0;

    void Start()
    {
        lives = totalLive;
        error_number = 0;
    }

    private void WrongNumber()
    {
        if (error_number < totalLive)
        {
            error_number++;
            lives--;
            text_error.text = error_number.ToString();
            text_error.color = Color.red;
        }
    }

    private void OnEnable()
    {
        GameEvents.OnWrongNumber += WrongNumber;
    }

    private void OnDisable()
    {
        GameEvents.OnWrongNumber -= WrongNumber;
    }
}
