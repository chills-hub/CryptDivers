using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellDelete : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DeleteShell());
    }

    private IEnumerator DeleteShell() 
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
