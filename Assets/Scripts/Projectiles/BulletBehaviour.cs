using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public EnemyContainer targetEnemy;
    public float speed = 0.2f;
    public int damage;
    public int damageType;
    public bool isBomb;
    public GameObject explosion;
    public int radius = 100;

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
            if (!isBomb)
            {
                collisionEnemyComponent.myHpManager.RemoveHp(damage, damageType);
                Destroy(gameObject);
            }
            else
            {
               
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
