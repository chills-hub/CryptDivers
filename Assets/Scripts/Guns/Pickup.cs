using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Animator PickupAnimator;
    private PickupManager PickupManager;

    /// <summary>
    /// The Type of pickup
    /// </summary>
    public enum PickupType 
    {
        Handgun = 0,
        SMG = 1,
        Shotgun = 2
    }

    // Start is called before the first frame update
    void Start()
    {
        PickupAnimator = GetComponent<Animator>();
        PickupManager = gameObject.AddComponent<PickupManager>();
        PickupAnimator.Play("Pickup_Spin");
    }

    private void OnTriggerEnter(Collider other)
    {
        PickupManager.ApplyPickup(gameObject.name);
        Destroy(transform.gameObject);
    }
}
