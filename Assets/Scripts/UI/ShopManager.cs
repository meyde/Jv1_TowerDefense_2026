using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shop;
    public TowerSpawn selectedTowerSpawn;
    public GoldManager goldmanager;


    private void Awake()
    {
        goldmanager = FindFirstObjectByType<GoldManager>();
    }

    public void OpenShop(TowerSpawn towerToSelect)
    {
        shop.SetActive(true);
        selectedTowerSpawn = towerToSelect;
    }

    public void CloseShop()
    {
        shop.SetActive(false);
    }

    public void CreateTower(Shooter towerPrefab)
    {
        if (towerPrefab.cost <= goldmanager.currentGold)
        {
            var tower = Instantiate(towerPrefab);
            goldmanager.AddGold(-towerPrefab.cost);
            tower.transform.position = selectedTowerSpawn.transform.position;
            Destroy(selectedTowerSpawn.gameObject);
            CloseShop();
        }
    }

}
