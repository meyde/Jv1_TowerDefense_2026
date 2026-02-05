using TMPro;
using UnityEngine;

public class ButtonShopBridge : MonoBehaviour
{
    public ShopManager shopManager;
    public Shooter towerToSpawn;
    public TextMeshProUGUI priceText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shopManager = FindFirstObjectByType<ShopManager>();
    }

    public void Update()
    {
        priceText.text = towerToSpawn.cost.ToString("00") + "$";
    }

    public void CallTowerBuy()
    {
        shopManager.CreateTower(towerToSpawn);
    }

}
