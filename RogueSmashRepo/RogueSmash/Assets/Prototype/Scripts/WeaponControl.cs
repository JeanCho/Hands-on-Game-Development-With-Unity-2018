using UnityEngine;



namespace MyCompany.RogueSmash.Prototype
{
    public class WeaponControl
    {
        [System.Serializable]
        public struct WeaponControlData
        {
            public GameObject projectilePrefab;
            public Transform projectileSpawnPoint;
        }
         
        private GameObject projectilePrefab;
        private Transform projectileSpawnPoint;

        public WeaponControl(WeaponControlData weaponData)
        {
            projectilePrefab = weaponData.projectilePrefab;
            projectileSpawnPoint = weaponData.projectileSpawnPoint;
        }

        public void Use()
        {
            SpawnProjectile();
        }

        private void SpawnProjectile()
        {
            GameObject spawnedProjectile = GameObject.Instantiate(projectilePrefab, 
                projectileSpawnPoint.transform.position, 
                projectileSpawnPoint.transform.rotation);

            Projectile projectile = spawnedProjectile.AddComponent<Projectile>();
            projectile.Init(projectileSpawnPoint.transform.forward);
            projectile.Shoot();
        }

    }

}
