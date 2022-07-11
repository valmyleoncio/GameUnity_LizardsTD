using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private float health;
    public int healthStart = 100;
    public int value = 50;
    public bool boss = false;
    private Transform target;
    private int wavePointIndex = 0;
    public Image healthBar;
    public int typeEnemy;

    void Start() 
    {
        target = Waypoints.points[0];
        if(typeEnemy == 1){ //Runner
            health = healthStart * (1.0f + (0.1f * (PlayerStats.Rounds - 1))) - 50;
            speed += PlayerStats.Rounds + 1;
        } else if(typeEnemy == 2){ //Normal
            health = healthStart * (1.0f + (0.1f * (PlayerStats.Rounds - 1)));
            speed += PlayerStats.Rounds;
        }else if(typeEnemy == 3){ //Tank
            health = healthStart * (1.0f + (0.1f * (PlayerStats.Rounds - 1))) + 50;
            speed += PlayerStats.Rounds - 3;
        }else{
            health = healthStart * (1.0f + (0.1f * PlayerStats.Rounds));
        }
    }

    void Update() 
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 8.0f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);

        if(Vector3.Distance(transform.position, target.position) <= 0.9f){
            GetNextWaypoint();
        }
    }

    public void TakeDamage ( int amount ){
        health -= amount;

        healthBar.fillAmount = health/healthStart;

        if (health <= 0)
        {   
            Die();
        }
    }

    public void Die(){
        PlayerStats.Money += value;
        if(boss == true){
            WaveSpawner.bossCheck = false;
        }
        Destroy(gameObject);
    }

    void GetNextWaypoint(){
        wavePointIndex++;
        if(wavePointIndex < Waypoints.points.Length){
            target = Waypoints.points[wavePointIndex];
        }else {
            EndPath();
        }
    }

    void EndPath (){
        if(boss == true){
            PlayerStats.Lives-=2;

            WaveSpawner.bossCheck = false;
        } else {
            PlayerStats.Lives--;
        }
        
        Destroy(gameObject);
    }
}
