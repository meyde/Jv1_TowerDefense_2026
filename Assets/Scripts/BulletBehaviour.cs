using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public EnemyContainer targetEnemy;
    public float speed = 0.2f;
    public int damage;
    public int damageType;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        if (targetEnemy == null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();

        if (collisionEnemyComponent != null)
        {

            collisionEnemyComponent.myHpManager.RemoveHp(damage,damageType);
            Destroy(gameObject);
        }
    }
}
