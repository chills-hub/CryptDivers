using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrel_ReloadShells : MonoBehaviour
{
    public GameObject shotgun_Shell;
    public GameObject shotgun_Shell_Origin;
    public ParticleSystem MuzzleFlashLeft;
    public ParticleSystem MuzzleFlashRight;

    public void LaunchShell() 
    {
        GameObject shell1 = Instantiate(shotgun_Shell, shotgun_Shell_Origin.transform.position, Quaternion.LookRotation(transform.forward,transform.right));
        shell1.transform.rotation = Quaternion.Euler(GenerateRandomSpins(), GenerateRandomSpins(), GenerateRandomSpins());
        shell1.GetComponent<Rigidbody>().AddTorque(new Vector3(GenerateRandomSpins(), GenerateRandomSpins(), GenerateRandomSpins()));
        shell1.GetComponent<Rigidbody>().velocity = GameObject.Find("Player").GetComponent<Rigidbody>().velocity;
        shell1.GetComponent<Rigidbody>().AddForce(shotgun_Shell_Origin.transform.up * 10, ForceMode.Impulse);
        GameObject shell2 = Instantiate(shotgun_Shell, shotgun_Shell_Origin.transform.position + new Vector3(0.1f, -0.1f, -0.1f), Quaternion.LookRotation(transform.forward,transform.right));
        shell2.transform.rotation = Quaternion.Euler(GenerateRandomSpins(), GenerateRandomSpins(), GenerateRandomSpins());
        shell2.GetComponent<Rigidbody>().velocity = GameObject.Find("Player").GetComponent<Rigidbody>().velocity;
        shell2.GetComponent<Rigidbody>().AddTorque(new Vector3(GenerateRandomSpins(), GenerateRandomSpins(), GenerateRandomSpins()));
        shell2.GetComponent<Rigidbody>().AddForce(shotgun_Shell_Origin.transform.up * 10, ForceMode.Impulse);
    }

    public void PlayMuzzleFlash() 
    {
        MuzzleFlashLeft.Play();
        MuzzleFlashRight.Play();
    }

    public float GenerateRandomSpins() 
    {
        var spin = Random.Range(0, 360);
        return spin;
    }
}
