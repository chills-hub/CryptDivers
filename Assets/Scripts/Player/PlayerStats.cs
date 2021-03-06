using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// Total Player Health
    /// </summary>
    public float TotalHealth 
    {
        get { return 100; }
    }

    /// <summary>
    /// Current Player Health
    /// </summary>
    public float CurrentHealth { get; set; }

    /// <summary>
    /// Total Player Armour
    /// </summary>
    public float TotalArmour
    {
        get { return 150; }
    }

    /// <summary>
    /// Current Player Armour
    /// </summary>
    public float CurrentArmour { get; set; }

}
