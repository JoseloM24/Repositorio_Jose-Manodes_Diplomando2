using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 30f;
    public int health = 1;
    private GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }
   

    public void Movement()
    {
       //Vector2 vector2 = new Vector2(Mathf.Cos(0.5f), Mathf.Sin(0.5f));
       // transform. Translate(Vector3.down * speed * Time.deltaTime);
       transform.Translate(new Vector3(Mathf.Sin(Time.time*1.5f), -1,0) * speed * Time.deltaTime);
    }
}
