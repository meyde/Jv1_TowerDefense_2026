using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public GameObject towerPrefab;
    private void OnMouseDown()
    {
        print("dbug");
        var tower = Instantiate(towerPrefab);
        tower.transform.position = transform.position;
        Destroy(gameObject);
    }
}
