using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public int currentGold = 50;
    public TextMeshProUGUI goldText;

    public void AddGold(int gold)
    {
        currentGold += gold;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = currentGold.ToString("00");
    }
}
