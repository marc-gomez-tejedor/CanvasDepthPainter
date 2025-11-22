using System.Collections;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    BulletConfigSO configSO;

    float bulletSpeed, bulletDamage, destroyTime;
    LayerMask destroyBulletLayerMask;

    Coroutine _returnToPoolTimerCoroutine;

    void Awake()
    {
    }

    void OnEnable()
    {
        bulletSpeed = configSO.speed;
        bulletDamage = configSO.damage;
        destroyTime = configSO.destroyTime;
        destroyBulletLayerMask = configSO.destroysBulletMask;

        SetDestroTime();
        InitializeBulletStats();

        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());    
    }
    void FixedUpdate()
    {
         
    }

    IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < destroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }

    void SetDestroTime()
    {

    }

    void InitializeBulletStats()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if((destroyBulletLayerMask.value & (1 << other.gameObject.layer)) > 0)
        {
            // spawn particles

            // play soundfx

            // screenshake

            // damage enemy
            IDamageable iDamageable = other.gameObject.GetComponent<IDamageable>();
            if(iDamageable != null)
            {
               iDamageable.Damage(bulletDamage);
            }


            // destroy bullet
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
