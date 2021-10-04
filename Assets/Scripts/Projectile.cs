using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float damage = 50;


    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //transform.Rotate(0, 0, 5f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();
       
        // If it has Attacker and Health Component
        if (attacker && health)
        {
            // Reduce health
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
        //Debug.Log("I hit " + otherCollider.name);
        
    }
}
