using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// The damage the weapon does per bullet
    /// </summary>
    public float WeaponDamage { get; set; }
    /// <summary>
    /// The total ammo count
    /// </summary>
    public float AmmoCount { get; set; }
    /// <summary>
    /// The current ammo for the gun
    /// </summary>
    public float CurrentAmmo { get; set; }
    /// <summary>
    /// The travel distance of bullets
    /// </summary>
    public float Range { get; set; }
    /// <summary>
    /// The falloff distance of bullet damage
    /// </summary>
    public float Falloff { get; set; }
    /// <summary>
    /// The Rate of fire
    /// </summary>
    public float FireRate { get; set; }
    /// <summary>
    /// The next time to fire
    /// </summary>
    public float NextTimeToFire { get; set; }
    /// <summary>
    /// The shot spread
    /// </summary>
    public float Spread { get; set; }
    /// <summary>
    /// Whether the player has the weapon
    /// </summary>
    public bool InInventory { get; set; }
    /// <summary>
    /// The type of ammo used
    /// </summary>
    public AmmoType AmmoType { get; set; }

    public Camera PlayerGunCamera;
    public ReferenceManager RefManager;
    public DecalEffectsManager DecalManager;
    [HideInInspector]
    public InputManager InputManager;

 
    public void Start()
    {
        RefManager = FindObjectOfType<ReferenceManager>();
        DecalManager = FindObjectOfType<DecalEffectsManager>();
        InputManager = FindObjectOfType<PlayerController>().GetComponent<InputManager>();
    }

    public void FireHitscanWeapon(Vector3 position, int numShots, float spread)
    {
        RaycastHit bulletHit;
        Vector3 direction = PlayerGunCamera.transform.forward;

        if (AmmoCount <= 0)
        {
            return;
        }
        else if (AmmoCount > 0 || AmmoCount == 50000000)
        {
            for (int i = 0; i < numShots; i++)
            {
                //BULLET SPREAD
                Vector3 finalDirection = (direction + Random.insideUnitSphere * spread).normalized;

                if (Physics.Raycast(position, finalDirection, out bulletHit, Range))
                {
                    DecalManager.ApplyDecalByType(bulletHit.transform.tag, bulletHit);

                    if (bulletHit.distance > Falloff)
                    {
                        //maybe split this out somehow?
                        WeaponDamage /= 2;
                    }

                    if (bulletHit.collider.gameObject.CompareTag("Enemy"))
                    {
                        //also split this out?
                        ApplyDamage(bulletHit.transform.GetComponent<Enemy>());
                    }
                }
            }
        }
    }

    public void SetNextFireTime()
    {
        NextTimeToFire = Time.time + 1f / FireRate;
    }

    public void DrainAmmo() 
    {
        if (AmmoType != AmmoType.Pistol)
        {
            if (AmmoType == AmmoType.Shotgun)
            {
                CurrentAmmo = CurrentAmmo - 2;
                return;
            }
            CurrentAmmo--;
        }
        else
        {
            return;
        }
    }

    public void ApplyDamage(Enemy enemy) 
    {
        enemy.TakeDamage(WeaponDamage);
    }
}

public enum AmmoType 
{
    SMG = 0,
    Rifle = 1,
    Shotgun = 2,
    Pistol = 3,
    Rocket = 4,
    Grenade = 5
}

