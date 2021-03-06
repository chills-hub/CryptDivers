using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibBloodSpatter : MonoBehaviour
{
    private DecalEffectsManager DecalManager;

    // Start is called before the first frame update
    void Start()
    {
        DecalManager = FindObjectOfType<DecalEffectsManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.contacts[0].otherCollider.tag == "Ground")
        {
            GameObject blood = DecalManager.ReturnGibSplatter();
            var rotation = Quaternion.FromToRotation(Vector3.up, collision.contacts[0].normal);
            int num = collision.contacts.Length - 1;
            var bloodSplatter = Instantiate(blood, collision.contacts[num].thisCollider.transform.position, rotation);
            Destroy(bloodSplatter, 10f);
        }
    }
}
