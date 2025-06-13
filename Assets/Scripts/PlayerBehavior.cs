using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    bool canInteract = false;
    // Stores the current coin object the player has detected
    Collectibles currentCoin = null;
    void OnInteract()
    {
        // Check if the player can interact with objects
        if (canInteract)
        {
            // Check if the player has detected a coin or a door
            if (currentCoin != null)
            {
                Debug.Log("Interacting with coin");
                // Call the Collect method on the coin object
                // Pass the player object as an argument
                currentCoin.Collect(this);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        // Check if the player detects a trigger collider tagged as "Collectible" or "Door"
        if (other.CompareTag("Collectible"))
        {
            // Set the canInteract flag to true
            // Get the CoinBehaviour component from the detected object
            canInteract = true;
            currentCoin = other.GetComponent<Collectibles>();
        }
    }
    
    

}
