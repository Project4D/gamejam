using System;
using UnityEngine;

public class EnemyBeta : MonoBehaviour
{
    private int damage = 50;
    
    void OnCollisionEnter(Collision collision)
    {
        Hamster hamster = collision.gameObject.GetComponent<Hamster>();
        Debug.Log("Touched");
        if (collision.collider.CompareTag("Player")) {
            
            if(hamster != null){
                hamster.TakeDamage(damage);
            }
        }
    }
}