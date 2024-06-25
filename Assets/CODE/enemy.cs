using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public int Health = 100;
    public int Value = 50;
    private void Start()
    {
       
        target = waypoint.points[0];
   
    }
    public void TakeDamage(int amount)
    {
        Health-=amount;
        if (Health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.Money += Value;
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            GetNextWaupoint();

        }

    }

    void GetNextWaupoint()
    {
        if (wavepointIndex >= waypoint.points.Length - 1)
        {
            EndPath();
         
            return;
        }
        wavepointIndex++;
        target = waypoint.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy (gameObject);
    }
}
