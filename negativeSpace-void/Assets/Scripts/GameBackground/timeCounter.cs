using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class timeCounter : MonoBehaviour
{

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown? currentTime - Time.deltaTime : currentTime + Time.deltaTime;
        int intTime = (int)currentTime;
        timerText.text = intTime.ToString();

    }
}
