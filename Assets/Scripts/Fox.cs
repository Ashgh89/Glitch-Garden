using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        // If this is GraveStone then do stuff
        if (otherObject.GetComponent<GraveStone>())
        {
            GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
            
        }
    }
}
