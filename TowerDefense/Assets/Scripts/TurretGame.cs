using UnityEngine;

public class TorreGame : MonoBehaviour
{
    private Transform target;

    [Header("Atributos")]

    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup fields")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if(target == null)
            return;

         Vector3 dir = target.position - firePoint.position;
         Quaternion lookRotation = Quaternion.LookRotation(dir);
         Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
         partToRotate.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);

         if(fireCountdown <= 0){
             Shoot();
             fireCountdown = 1f / fireRate;
         }

         fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        if(target == null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float distanceToEnemy = 0;

            foreach (GameObject enemy in enemies)
            {
                distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy <= range) {
                    target = enemy.transform;
                    break;
                } else{
                    target = null;
                }
            }
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {   
            bullet.Seek(target);
        }
    }   

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
