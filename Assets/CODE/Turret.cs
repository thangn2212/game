using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    [Header("Setup")]
    public float range = 15f;
    public string enemyTag = "Enemy";
    public Transform parttorotate;
    public float turnspped = 10f;

    [Header("Attributes")]

    public float fireRate = 1f;
    public float firecount = 0f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    




    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);// tìm tất cả ojecht có tag là enmy
        float shortdistance= Mathf.Infinity;
        GameObject nerestEnemy  = null;
        foreach (GameObject enemy in enemies)

        {
            float distanceToenemy = Vector3.Distance(transform.position, enemy.transform.position); 
            if (distanceToenemy < shortdistance) {
                shortdistance = distanceToenemy;
                nerestEnemy = enemy;
            }
        }
        if (nerestEnemy != null && shortdistance<= range )
        {
            target = nerestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
  
    void Update()
    {
        if ( target == null ) {
            return;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(parttorotate.rotation,lookRotation,Time.deltaTime*turnspped).eulerAngles;

        parttorotate.rotation = Quaternion.Euler(0f ,rotation.y,0f) ;

        if (firecount <= 0  )
        {
            firecount =1f/ fireRate;
            Shoot();
        }

        firecount -= Time.deltaTime;    
    }
    void Shoot ()
    {
        GameObject butletGo =(GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet buulet = butletGo.GetComponent<Bullet>();
        if ( buulet != null )

        {
            buulet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
