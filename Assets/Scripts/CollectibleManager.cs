using TMPro;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;
    public int currentCollectibles = 0;
    public TextMeshProUGUI CollectiblesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Start()
    {
        UpdateCollectibleText();
    }

    public void AddScore(int amount)
    {
        currentCollectibles += amount;
        UpdateCollectibleText();

    }
    void UpdateCollectibleText()
    {
        CollectiblesText.text = "Collectibles: " + currentCollectibles.ToString();
        }
    }


