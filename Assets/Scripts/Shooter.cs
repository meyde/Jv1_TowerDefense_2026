using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public List<EnemyContainer> enemiesInRange;
    public EnemyContainer targetEnemy;
    public float shootTime;
    public int dammage;
    public Color bulletColor;
    public BulletBehaviour bulletPrefab;
    
    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        SetTargetEnemy();   
    }
    
    private IEnumerator Shoot()
    {
        while (true)
        {
            while(targetEnemy == null)
            {
                yield return new WaitForEndOfFrame();
            }
            ShootAction();
            yield return new WaitForSeconds(shootTime);
        }
    }

    private void ShootAction()
    {
        var newBullet = Instantiate(bulletPrefab);
     
        newBullet.targetEnemy = targetEnemy;
        newBullet.dammage = dammage;
        newBullet.spriteRenderer.color = bulletColor;
        newBullet.transform.position = transform.position;
    }

    private void BowTarget()
    {
        var minPos = 0;
        var i = 0;
        foreach (EnemyContainer enemy in enemiesInRange)
        {
            i += 1;
            if (enemy.myHpManager.currentHP < enemiesInRange[minPos].myHpManager.currentHP) { minPos = i; };
        }
        targetEnemy =enemiesInRange[minPos];

    }
    private void SetTargetEnemy()
    {
        if(enemiesInRange.Count<=0)
        {
            targetEnemy = null;
        }
        else
        {
            BowTarget();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();
        if (collisionEnemyComponent != null)
        {
            enemiesInRange.Add(collisionEnemyComponent);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyContainer collisionEnemyComponent = collision.gameObject.GetComponent<EnemyContainer>();
        if (collisionEnemyComponent != null)
        {
            enemiesInRange.Remove(collisionEnemyComponent);
        }
    }
}
