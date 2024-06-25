
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform Target;
    public float spped = 70f;
    public float explosionRadius = 0f ;
    public GameObject impacecteffect;
    public int damage = 50;
    public void Seek(Transform _taget)
    {
        Target = _taget;
    }
    void Update()
    {
     
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = Target.position - transform.position;
        float dstanceThisFrame = spped *Time.deltaTime;
        if (dir.magnitude <= dstanceThisFrame) {
            HitTarget();
            
            return;
        }
        transform.LookAt(Target);// nhìn vào mục tiêu 
        transform.Translate(dir.normalized * dstanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectint = (GameObject)Instantiate(impacecteffect, transform.position, transform.rotation);
        //Destroy(Target.gameObject);
        Destroy(effectint, 2f);
        if (explosionRadius > 0)
        {
            Explode();
        }else
        {
            Damage(Target);
        }
        Destroy(gameObject);
    }
    void Explode()
    {
        // Kiểm tra và trả về tất cả các Collider nằm trong phạm vi của vụ nổ
        Collider[] cooloders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in cooloders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        enemy e = enemy.GetComponent<enemy>();
      if (e != null) {
         
          e.TakeDamage(damage);
           
        }
      
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
