using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusShooter : MonoBehaviour
{

    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator myAnimator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        myAnimator = GetComponent<Animator>();
        CreatProjectileParent();
    }

    private void CreatProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            myAnimator.SetBool("isAttacking", true);
        }
        else
        {
            myAnimator.SetBool("isAttacking", false);

        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            var spaceBetween = Mathf.RoundToInt(spawner.transform.position.y - transform.position.y);
            bool IsClodeEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (spaceBetween == 0)
            {
                IsClodeEnough = true;
            }
            if (IsClodeEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        // If my lane spawner child count less than 0 or equal to 0, return false
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;

    }
    // as GameObject means that we neede this as a GameObject so that we can place it within our hierarchy and we can manipulate it. 
}
