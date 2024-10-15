using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float speed = 5.5f;
    public float fireRate = 0.25f;
    public int lives = 3;
    public int shields = 3;
    public float canFire = 0.0f; //Time to fire again
    public float shieldDuration = 5.0f;
    public float Health = 10.0f;
    public float maxHealth = 10.0f;
    public GameObject BulletPref;

    //To use audio
    public AudioManager audioManager;
    public AudioSource actualAudio;
    public int playerWeapon = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckBoundaries();
        ChangeWeapon();
        //UseShields();
        Fire();
    }

    //Character Movement, use WASD keys to move the player
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
    }

    void CheckBoundaries()
    {
        //Check for boundaries of the game, use Main Camera to set the boundaries
        var cam = Camera.main;
        float xMax = cam.orthographicSize * cam.aspect;
        float yMax = cam.orthographicSize;
        if (transform.position.x > xMax)
        {
            transform.position = new Vector3(-xMax, transform.position.y, 0);
        }
        else if (transform.position.x < -xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, 0);
        }
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, -yMax, 0);
        }
        else if (transform.position.y < -yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, 0);
        }
    }

    //Player Fire
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            switch (BulletPref.name)
            {
                case "Bullet": //Instantiate the bullet in the center
                    Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    //Play the sound of the bullet
                    actualAudio.Play();
                    break;
                case "Missile": //Instantiate 3 bullets, one in the center and the other two in diagonal
                                //Instantiate the bullet in the center
                    var bullet1 = Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    Debug.Log(bullet1.GetComponent<Missile>().direction);
                    bullet1.GetComponent<Missile>().direction = Vector2.up;

                    //Instantiate the bullet in the right
                    var bullet2 = Instantiate(BulletPref, transform.position + new Vector3(0.5f, 0.8f, 0), Quaternion.identity);
                    bullet2.GetComponent<Missile>().direction = new Vector2(0.5f, 1);

                    //Instantiate the bullet in the left
                    var bullet3 = Instantiate(BulletPref, transform.position + new Vector3(-0.5f, 0.8f, 0), Quaternion.identity);
                    bullet3.GetComponent<Missile>().direction = new Vector2(-0.5f, 1);

                    canFire = Time.time + fireRate;
                    //Play the sound of the bullet
                    actualAudio.pitch = Random.Range(1f, 1.5f);
                    actualAudio.Play();

                    break;
                case "Energy Ball": //Instantiate the bullet in a wave pattern
                    Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    actualAudio.pitch = Random.Range(0.5f, 1f);
                    actualAudio.Play();


                    break;
                case "Rayo": //Instantiate the bullet in a wave pattern
                    Instantiate(BulletPref, transform.position + new Vector3(0, 2f, 0), Quaternion.identity);
                    canFire = Time.time + fireRate;
                    actualAudio.pitch = Random.Range(0.7f, 5f);
                    actualAudio.Play();


                    break;

            }
        }
        //if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        /*{
            Instantiate(BulletPref, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
            canFire = Time.time + fireRate;

            //paly the sound of the bullet
            //actualAudio = audioManager.GetAudio("Bullet");
            actualAudio.Play();
            break;
        }*/
    }
    //public GameObject BulletPref; ----> esta es la bala que se va a disparar

    public List<Bullet> bullets;
    internal int actualWeapon;

    public void ChangeWeapon()
    {
        //For changing weapons, use the number keys 1, 2, 3, 4

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BulletPref = bullets[0].gameObject;
            actualWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BulletPref = bullets[1].gameObject;
            actualWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BulletPref = bullets[2].gameObject;
            actualWeapon = 2;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BulletPref = bullets[3].gameObject;
            actualWeapon = 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
               // GameManager gameManager = FindObjectOfType<GameManager>();
                //gameManager.PerderVida();
                //destroy the enemy
                Destroy(collision.gameObject);
                //Destroy the player
                //Destroy(this.gameObject);
                if (lives > 1)
                {
                    lives--;
                    Debug.Log("lives:" + lives);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }

    }
}
   