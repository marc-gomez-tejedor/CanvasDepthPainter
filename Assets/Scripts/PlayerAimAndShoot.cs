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
            Instantiate(bulletLeftClick, bulletSpawnPoint.position, gun.transform.rotation);
            
            // particles
            Instantiate(particlesLeftClick, bulletSpawnPoint.position, gun.transform.rotation);
        }
        if (Input.GetMouseButton(1))
        {
            // spawn bullets
            Instantiate(bulletRightClick, bulletSpawnPoint.position, gun.transform.rotation);
            
            // particles
            Instantiate(particlesRightClick, bulletSpawnPoint.position, gun.transform.rotation);
        }
        if (Input.GetMouseButton(3))
        {
            Instantiate(circleThing, bulletSpawnPoint);
        }
    }
}
