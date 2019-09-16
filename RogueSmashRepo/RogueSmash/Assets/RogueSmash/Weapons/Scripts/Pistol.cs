using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyCompany.RogueSmash.Player;
using MyCompany.GameFramework.Coroutines;


namespace MyCompany.RogueSmash.Weapons
{
    public class Pistol : IWeapon
    {
        private WeaponData weaponData;
        private int currentAmmo;
        private bool isReloading = false;
        private float lastFire = 0;
        private Transform actorLocation;

        public Pistol(WeaponData weaponData, GameObject actor)
        {
            this.weaponData = weaponData;
            currentAmmo = weaponData.MaxAmmo;
            actorLocation = actor.transform;

        }

        public bool Shoot()
        {
            if(lastFire + weaponData.MinFireInterval > Time.time)
            {
                Debug.LogWarning("CLICK");
                return false;
            }
            
            if(isReloading)
            {
                Debug.LogWarning("RELOADING");
                return false;
            }

            if(currentAmmo >0)
            {
                currentAmmo--;
                lastFire = Time.time;
                SpawnProjectile();
                Debug.Log("PEW" + currentAmmo + "/" + weaponData.MaxAmmo);
                return true;
            }

            if(currentAmmo <=0 && weaponData.DoesAutoReload)
            {
                Debug.LogWarning("RELOADING");
                Reload();
                return false;
            }
            else
            {
                Debug.LogWarning("OUT OF AMMO!");
                return false;
            }
        }

        public void SpawnProjectile()
        {
            GameObject instance = GameObject.Instantiate(weaponData.ProjectilePrefab, 
                actorLocation.position, actorLocation.rotation);
            instance.name = "Projectile";
            Rigidbody rb = instance.GetComponent<Rigidbody>();
            rb.velocity = rb.transform.forward.normalized * weaponData.ProjectileSpeed;
            GameObject.Destroy(instance, 5.0f);
        }

        public void Reload()
        {
            isReloading = true;
            CoroutineHelper.RunCoroutine(ReloadTimer);
        }

        private IEnumerator ReloadTimer()
        {
            float timer = 0;
            while(timer <= weaponData.ReloadTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            Debug.LogError("RELOAD COMPLETE");
            currentAmmo = weaponData.MaxAmmo;
            isReloading = false;
        }
    }
}

