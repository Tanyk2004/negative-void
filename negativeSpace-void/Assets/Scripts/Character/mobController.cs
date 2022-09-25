using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobController : MonoBehaviour
{
    public Transform characterTransform;
    public GameObject player;

    [Header("Mob Settings")]
    public int damage = 10;
    public int characterHealth = 100;

    public float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Rigidbody2D characterRigidbody;
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {        
	  //program the bot here

    if (timeBetweenAttack <= 0){
	if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 1.5){
	  	player.GetComponent<CharacterAttributes>().takeDamage(damage);
         
	  	if (player.transform.position.x > gameObject.transform.position.x){
	  		player.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);              	
			timeBetweenAttack = startTimeBetweenAttack;
	  	}
	  	if (player.transform.position.x < gameObject.transform.position.x){
	  		player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1*5f, 5f), ForceMode2D.Impulse);              	
			timeBetweenAttack = startTimeBetweenAttack;
	  	}
       } else {
              timeBetweenAttack -= Time.deltaTime;
       }



	  

	  }
    }

    void FixedUpdate()
    {
        if (player.transform.position.x > gameObject.transform.position.x){
		characterTransform.Translate(Time.deltaTime, 0f, 0f);
	  }
	  if (player.transform.position.x < gameObject.transform.position.x){
		characterTransform.Translate(-1*Time.deltaTime, 0f, 0f);
	  }
	  //program the bot here
    }

    public void takeDamage(int damage)
    {
        Debug.Log("Mob took damage" + damage);
	  if (player.transform.position.x > gameObject.transform.position.x){
		characterRigidbody.AddForce(new Vector2(-1*5f, 5f), ForceMode2D.Impulse);
	  }
	  if (player.transform.position.x < gameObject.transform.position.x){
	  	characterRigidbody.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
	  }
        
        characterHealth -= damage;
    }
}
