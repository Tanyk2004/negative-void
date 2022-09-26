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
    public float groundRange = 0.5f;
    public LayerMask groundLayer;
    public float timeBetweenAttack = 1;
    public float startTimeBetweenAttack = 1;
    public Transform checkFall;
    public Rigidbody2D characterRigidbody;
    public float moveSpeed = 10.0f;
    // Start is called before the first frame update


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {        
	  //program the bot here

    
	if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 1.5){
	  	Debug.Log("Took From Player");
      player.GetComponent<CharacterAttributes>().takeDamage(damage);
         
	  	if (player.transform.position.x > gameObject.transform.position.x){
	  		player.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);              	
			timeBetweenAttack = startTimeBetweenAttack;
	  	}
	  	if (player.transform.position.x < gameObject.transform.position.x){
	  		player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1*5f, 5f), ForceMode2D.Impulse);              	
			timeBetweenAttack = startTimeBetweenAttack;
	  	}
       
	  }
    }

    void FixedUpdate()
    {
      if( characterHealth <= 0){
        Die();
      }
      if( isFallen()){
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
      }
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
    private bool isFallen(){
        Collider2D[] detectGround = Physics2D.OverlapCircleAll(checkFall.position, 
                groundRange, groundLayer);
        int collisionlength = detectGround.Length;
        if (collisionlength > 0){
            return true;
        }
        else{
            return false;
        }

        
    }
    private void Die(){
      Destroy(gameObject);
      player.GetComponent<CharacterAttributes>().addScore(1);
    }
    
    //creates Gizmos to help with debugging
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkFall.position, groundRange);
    }
}
