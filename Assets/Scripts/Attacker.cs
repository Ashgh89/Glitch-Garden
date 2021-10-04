using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{

   
    [Range (0,5)]
    float currentSpeed = 1;

    GameObject currentTarget;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {

        // How many enemy is in the scene
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();

    }
    public void SetMovementSpeed(float speed)

    {
        currentSpeed = speed;
    }
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }
}
