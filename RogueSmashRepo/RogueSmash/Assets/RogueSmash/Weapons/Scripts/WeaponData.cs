using System;
using UnityEngine;

namespace MyCompany.RogueSmash.Player
{
    [Serializable]
    public class WeaponData 
    {
        [Header("General Characteristics")]
        [SerializeField] private int maxAmmo;
        [SerializeField] private float minFireInterval;
        [Header("Reload")]
        [SerializeField] private float reloadTime;
        [SerializeField] private bool doesAutoReload;
        [Header("Projectile")]
        [SerializeField] private float baseDamage;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private GameObject projectilePrefab;

        public int MaxAmmo
        {
            get { return maxAmmo;  }
        }
        public float MinFireInterval
        {
            get { return minFireInterval; }
        }
        public float ReloadTime
        {
            get { return reloadTime; }
        }

        public bool DoesAutoReload
        {
            get { return doesAutoReload; }
        }

        public float BaseDamage
        {
            get { return baseDamage; }
        }

        public float ProjectileSpeed
        {
            get { return projectileSpeed; }
        }

        public GameObject ProjectilePrefab
        {
            get { return projectilePrefab; }
        }
    }
}

