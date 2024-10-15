using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float detectionRadius = 5.0f;
    public float speed = 5.0f;
    public int health = 3;


    //private GameObject explosionPrefab;

    private Rigidbody2D rb;
    private Vector2 movement;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
            if (player == null)
            {
                Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            movement = new Vector2(direction.x, direction.y);

    }
        else 
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemigo recibió daño. Salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Método para destruir al enemigo
    void Die()
    {
        Debug.Log("Enemigo destruido.");
        Destroy(gameObject);
    }

    // Detectar colisiones con balas
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1); // Recibe 1 de daño por cada bala
            Destroy(collision.gameObject); // Destruye la bala tras colisionar
        }
    }
}
