using UnityEngine;

public class ShovelGrabber : MonoBehaviour
{
    private bool isGrabbed = false;
    private Rigidbody shovelRigidbody;

    private void Start()
    {
        shovelRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check for input to grab/release the shovel
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (isGrabbed)
                ReleaseShovel();
            else
                GrabShovel();
        }
    }

    private void GrabShovel()
    {
        // Disable physics simulation while grabbing
        shovelRigidbody.isKinematic = true;
        isGrabbed = true;
    }

    private void ReleaseShovel()
    {
        // Enable physics simulation after releasing
        shovelRigidbody.isKinematic = false;
        isGrabbed = false;
    }
}
