using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float explosionRadius = 0f;
    public int damage = 50;
    public float speed = 70f;
    public GameObject effect;

    void Update(){

        if (target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(this.transform.rotation, lookRotation, Time.deltaTime * speed).eulerAngles;
        this.transform.rotation = Quaternion.Euler(0f, rotation.y, rotation.z); 

        if(dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectGO = (GameObject) Instantiate(effect, transform.position, transform.rotation);
        Destroy(effectGO, 2f);

        if(explosionRadius > 0){
            Explode();
        } else {
            Damage(target);
        }
 
        Destroy(gameObject);
    }

    void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy"){
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy){

        Enemy e = enemy.GetComponent<Enemy>();

        if(e != null){
            e.TakeDamage(damage);
        }
    }

    public void Seek(Transform _target){
        target = _target;
    }
}
