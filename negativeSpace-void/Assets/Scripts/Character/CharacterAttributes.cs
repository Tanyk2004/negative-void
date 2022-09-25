using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterAttributes : MonoBehaviour
{
    public int health;
    public int rage;
    public int tokens;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        setHealth(100);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBar.maxValue += 50;
        }
    }

    public void setHealth(int health)
    {
        this.health = health;
        healthBar.value = health;
    }
}
