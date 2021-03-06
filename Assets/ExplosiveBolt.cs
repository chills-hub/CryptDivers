using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBolt : MonoBehaviour
{
    // Grenade explodes after a time delay.
    public float fuseTime;
    public float radius;
    public float power;
    [HideInInspector]
    public float damage;
    public GameObject Explosion;
    public AudioSource ExplosionAudio;
    public ParticleSystem Fuse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            Invoke(nameof(Explode), fuseTime);
        }
        else if (other.gameObject.tag == "Enemy") 
        {
            Explode();
        }
    }

    void Explode() 
    {
        ExplosionAudio.Play();
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (hit.gameObject.tag == "Enemy") 
            {
                hit.gameObject.GetComponent<EnemyCore>().TakeDamage(damage);
            }

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius);
        }
        transform.localScale = new Vector3(0f, 0f, 0f);
        Fuse.Stop();
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    IEnumerator FuseTime()
    {
        yield return new WaitForSeconds(fuseTime);
        Destroy(this.gameObject);
    }
}
