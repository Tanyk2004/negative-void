using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobController : MonoBehaviour
{
    public Transform characterTransform;
    [Header("Mob Settings")]
    public int characterHealth = 100;
    public Rigidbody2D characterRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //program the bot here
    }
    public void takeDamage(int damage)
    {
        Debug.Log("Mob took damage" + damage);
        characterRigidbody.AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
        characterHealth -= damage;
    }
}
