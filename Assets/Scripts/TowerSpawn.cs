using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    public GameObject towerPrefab;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindFirstObjectByType<ShopManager>();
    }

    private void OnMouseDown()
    {
        shopManager.OpenShop(this);
    }
}
