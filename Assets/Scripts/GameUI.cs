using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    // Reference to the top-right collectible tracker UI
    public TextMeshProUGUI collectiblesText;

    // Reference to the message shown near the door
    public TextMeshProUGUI doorMessageText;

    // Update the collectible UI text (e.g. "Collectibles: 2/5")
    public void UpdateCollectibleUI(int current, int total)
    {
        if (collectiblesText != null)
        {
            collectiblesText.text = $"Collectibles: {current}/{total}";
        }
    }

    // Show a door-related message (e.g. "Press E to open")
    public void ShowDoorMessage(string message)
    {
        if (doorMessageText != null)
        {
            doorMessageText.text = message;
            doorMessageText.gameObject.SetActive(true);
        }
    }

    // Hide the door message
    public void HideDoorMessage()
    {
        if (doorMessageText != null)
        {
            doorMessageText.gameObject.SetActive(false);
        }
    }
}