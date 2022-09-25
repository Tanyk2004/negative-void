using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterAttributes : MonoBehaviour
{
    public int health;
    public int rage;
    public int tokens;
    public Slider healthBar;
    public int Score = 0;
    [Header("UI")]
    public TextMeshProUGUI scoreText;
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
            healthBar.value += 50;
        }

        
    }

    public void setHealth(int health)
    {
        this.health = health;
        healthBar.value = health;
    }
    public void takeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
    }
    public void setRage(int rage)
    {
        this.rage = rage;
    }
    void onCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit mob");
        if(Input.GetMouseButtonDown(0) && collision.gameObject.tag == "mob")
        {
            
            collision.gameObject.GetComponent<mobController>().takeDamage(10);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 50f), ForceMode2D.Impulse);
        }
        
    }
    
    public void addScore(int score)
    {
        this.Score += score; 
         scoreText.text = "x"+this.Score.ToString();}

}
