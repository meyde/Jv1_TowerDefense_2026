using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public int damage;
    public int damageType;
    public int radius=10;


    void Start()
    {
        Exploding();
        Destroy(gameObject);
    }
    private void Exploding()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(new Vector2 (transform.position.x,transform.position.y), radius);
        foreach (Collider2D hit in hits)
        {
            EnemyContainer enemy = hit.GetComponent<EnemyContainer>();
            if ( enemy != null)
            {
                enemy.myHpManager.RemoveHp(damage, damageType);
            }
        }
    }
}
