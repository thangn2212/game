using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavespaw : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawpoint;

    public float timeBetweenWaves = 5f;
    private float coutdown = 2f;
    private int waveMunber = 1;

    public Text waveCountdownText;


    private void Update()
    {
        if  (coutdown <= 0f)
        {
            StartCoroutine(SpawWave());
            coutdown = timeBetweenWaves;
            coutdown = Mathf.Clamp(coutdown,0f,Mathf.Infinity);// giới hạn thù 0 đến vô cực 
        }
        coutdown -= Time.deltaTime;

        waveCountdownText.text = string.Format("{0:00.00}", coutdown) ;// Đinhj dạng của chuỗi 

    }

    IEnumerator SpawWave()
    {
        for (int i = 0; i < waveMunber; i++)
        {
            spawenemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveMunber++;
    }
    void spawenemy()
    {
        Instantiate(enemyPrefab,spawpoint.position,spawpoint.rotation);
    }

}
