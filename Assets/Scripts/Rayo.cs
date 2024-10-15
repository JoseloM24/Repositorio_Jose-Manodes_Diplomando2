using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : Bullet
{
    // Start is called before the first frame update
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with:" + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy the enemy
            gameManager.AddScore(20);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame


}
