using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelInteraction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            GroundInteractionScript groundInteraction = other.transform.parent.GetComponent<GroundInteractionScript>();

            if (groundInteraction != null)
            {
                groundInteraction.Interact();
            }
        }
    }
}
