using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public EnemyContainer targetEnemy;
    public float speed = 0.2f;
    public int dammage;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        if (targetEnemy == null)
        {
               Destroy(gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetEnemy.transform.position, speed);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();

        if (collisionEnemyComponent != null)
        {

            collisionEnemyComponent.myHpManager.RemoveHp(dammage,0);
            Destroy(gameObject);
        }
    }
}
