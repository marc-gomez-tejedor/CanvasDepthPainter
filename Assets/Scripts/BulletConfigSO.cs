using UnityEngine;

[CreateAssetMenu(menuName = "Bullets")]
public class BulletConfigSO : ScriptableObject
{
    public float speed;
    public float damage;
    public float destroyTime;
    public LayerMask destroysBulletMask;
}
