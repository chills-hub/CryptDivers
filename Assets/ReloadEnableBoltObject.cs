using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadEnableBoltObject : MonoBehaviour
{
    public GameObject ObjectToEnable;
    public void EnableBolt() 
    {
        ObjectToEnable.SetActive(true);
    }
}
