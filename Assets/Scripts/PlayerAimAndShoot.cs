using UnityEngine;

public class PlayerAimAndShoot : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameObject bulletLeftClick;
    [SerializeField]
    GameObject bulletRightClick;
    [SerializeField]
    GameObject particlesLeftClick;
    [SerializeField]
    GameObject particlesRightClick;
    [SerializeField]
    GameObject circleThing;

    [SerializeField]
    GameObject gun;
    [SerializeField]
    Transform bulletSpawnPoint;

    void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }

    void HandleGunRotation()
    {

    }

    void HandleGunShooting()
    {
        if (Input.GetMouseButton(0))
        {
            // spawn bullets
            ObjectPoolManager.SpawnObject(bulletLeftClick, bulletSpawnPoint.position, gun.transform.rotation, ObjectPoolManager.PoolType.GameObject);

            // particles
            ObjectPoolManager.SpawnObject(particlesLeftClick, bulletSpawnPoint.position, gun.transform.rotation, ObjectPoolManager.PoolType.ParticleSystem);
        }
        if (Input.GetMouseButton(1))
        {
            // spawn bullets
            ObjectPoolManager.SpawnObject(bulletRightClick, bulletSpawnPoint.position, gun.transform.rotation, ObjectPoolManager.PoolType.GameObject);

            // particles
            ObjectPoolManager.SpawnObject(particlesRightClick, bulletSpawnPoint.position, gun.transform.rotation, ObjectPoolManager.PoolType.ParticleSystem);
        }
        if (Input.GetMouseButton(3))
        {
            ObjectPoolManager.SpawnObject(circleThing, bulletSpawnPoint);
        }
    }
}
