using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MagicPathing : MonoBehaviour
{
    public BulletBehaviour mbb;
    private Vector3 targetDirection;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        targetDirection = (mbb.targetEnemy.transform.position - transform.position);
        transform.position += targetDirection * mbb.speed;
    }
}
