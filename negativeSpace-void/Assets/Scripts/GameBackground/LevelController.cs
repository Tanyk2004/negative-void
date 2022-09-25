using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    

    [Header("Realm Switch bounds")]
    public int randomizerLowerBound;
    public int randomizerUpperBound;

    private int secondsLastSwitched = 0;
    private int secondsToSwitch = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        int intTime = (int)currentTime;
        timerText.text = intTime.ToString();

        if( currentTime >= secondsLastSwitched + secondsToSwitch){
            
            SwitchRealm();
            secondsLastSwitched = (int)currentTime;
            int secondsToSwitch = RandomizeRealmSwitch();
        }

    }

    private int RandomizeRealmSwitch()
    {
        return Random.Range(randomizerLowerBound, randomizerUpperBound);
    }

    private void SwitchRealm()
    {
        Debug.Log("Switching Realm");
    }
}
