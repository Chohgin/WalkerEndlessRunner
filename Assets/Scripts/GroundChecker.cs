using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public CharacterMovement cMovement;

    private void Start()
    {
        cMovement = GetComponentInParent<CharacterMovement>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == cMovement.gameObject)
            return;
        if (other.GetComponent<Coin>() != null)
            return;

        cMovement.isGrounded = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        cMovement.isGrounded = false;
    }
}
