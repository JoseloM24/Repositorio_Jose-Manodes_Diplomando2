using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public float spawnTime = 1.5f;
    public float spawnTime2 = 1.5f;
    public float time = 0.0f;
    public float totaltime = 0.0f;
    public Player player;
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI shieldsText;
    public TextMeshProUGUI weaponText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
  



    public int score = 0;

    private int vidas = 3;


    // Update is called once per frame
    void Update()
    {

        CreateEnemy();
        CreateEnemy2();
        UpdateCanvas();
        ChangeBulletImage(player.actualWeapon);
        totaltime += Time.deltaTime;
    }

    void UpdateCanvas()
    {
        //UpdateLives(); // Actualizar las imágenes de vidas
        liveText.text = "vidas: " + player.lives;
        shieldsText.text = "escudos: " + player.shields;
        //weaponText.text = "arma: " + player.BulletPref.name;
        scoreText.text = "puntos: " + score.ToString();
        //truncate the time to no show decimals
        timeText.text = "tiempo: " + totaltime.ToString("F0");

        

    }

    public void CreateEnemy()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-8.0f, 8.0f), 7.0f, 0), Quaternion.identity);
            time = 0.0f;
        }
    }
    public void CreateEnemy2()
    {
        time += Time.deltaTime;
        if (time > spawnTime2)
        {
            Instantiate(enemyPrefab2, new Vector3(Random.Range(-3.0f, 3.0f), 5.0f, 0), Quaternion.identity);
            time = 0.0f;
        }
    }
    public void AddScore(int value)
    {
        score += value;
    }

    [Header("UI")]
    public Image bulletImage;
    public List<Sprite> bulletSprites;
    public void ChangeBulletImage(int index)
    {
        Debug.Log("ChangeBulletImage: " + index);
        bulletImage.sprite = bulletSprites[index];
    }


    public LiveImage liveImage; 
    public void PerderVida()
    {
        vidas -= 1;
        liveImage.DesactivarVida(vidas); 
    }
   
    //public void RecuperarVida()
    //{
    //  liveImage.ActivarVida(vidas);
    //vidas += 1;
    //}
}
