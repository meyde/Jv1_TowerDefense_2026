using System.Runtime.InteropServices;
using UnityEngine;

public class ArrowPathing : MonoBehaviour
{
    public BulletBehaviour mbb;
    public Vector3 targetPosition, initiPosition, initUp;
    public AnimationCurve cloche;

    public float f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initiPosition = transform.position;
        initUp = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        var targetDirection = (targetPosition - initiPosition).normalized;
        var angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle - 90);
        targetPosition = mbb.targetEnemy.transform.position;
        transform.position = Vector3.Lerp(initiPosition, targetPosition, f) + initUp*cloche.Evaluate(f)*mbb.speed; 
        f += Time.deltaTime;
    }
}
