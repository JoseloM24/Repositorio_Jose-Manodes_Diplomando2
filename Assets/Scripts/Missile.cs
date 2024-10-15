using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    public Vector2 direction;
    // Start is called before the first frame update
    void Update()
    {
        Movement();
    }

    // Update is called once per frame
    public override void Movement()
    {
        //use direction to move bullet in a straight line pattern
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with:" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy the enemy
            gameManager.AddScore(10);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
