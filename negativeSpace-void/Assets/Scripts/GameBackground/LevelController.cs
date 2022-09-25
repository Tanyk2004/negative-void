using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    

    [Header("Timer Settings")]
    public float currentTime;
    

    [Header("Realm Switch bounds")]
    public int randomizerLowerBound;
    public int randomizerUpperBound;

    private int secondsLastSwitched = 0;
    private int secondsToSwitch = 10;
    
    [Header("Realm Switch Settings")]
    public bool dayActive = true;
    public SpriteRenderer background;
    public SpriteRenderer background2;
    public Sprite backgroundDay;
    public Sprite backgroundNight;
    public SpriteRenderer Ground;
    public SpriteRenderer Ground2;
    public Sprite groundPositive;
    public Sprite groundNegative;
    
    [Header("Mob Settings")]
    public GameObject mob;
    public Transform mobSpawnPoint;
    public int lowerBoundForce;
    public int upperBoundForce;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        int intTime = (int)currentTime;
       
        if (Input.GetKeyDown(KeyCode.E)) SpawnMobs();
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
        if (dayActive)
        {
            background.sprite = backgroundNight;
            background2.sprite = backgroundNight;
            Ground.sprite = groundNegative;
            Ground2.sprite = groundNegative;
            dayActive = false;
            SpawnMobs();
        }
        else
        {
            background.sprite = backgroundDay;
            background2.sprite = backgroundDay;
            Ground.sprite = groundPositive;
            Ground2.sprite = groundPositive;
            dayActive = true;
        }
    }

    private void SpawnMobs(){
        Instantiate(mob, mobSpawnPoint.position, mobSpawnPoint.rotation);
        float force = (float)Random.Range(lowerBoundForce, upperBoundForce);
        mob.GetComponent<Rigidbody2D>().AddForce(new Vector2((-1.0f) * force, force), ForceMode2D.Impulse);
    }
}
