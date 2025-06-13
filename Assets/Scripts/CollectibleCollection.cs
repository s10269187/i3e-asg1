using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CollectibleCollection : MonoBehaviour
{
    public int collectible = 0;
    private int health = 100; // Initial health value
    public TextMeshProUGUI collectiblecount;  // Reference to the TMP Text element
    public TextMeshProUGUI healthText; // Reference to the TMP Text element for health
    public Transform spawnPoint;

    void Start()
    {
        UpdateCollectibleCount();
        UpdateHealthUI();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectibles"))
        {
            collectible++;
            Destroy(other.gameObject);
            UpdateCollectibleCount();
            Debug.Log("Collectibles Collected : " + collectible);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            health -= 10; // Decrease health by 10 when colliding with lavva
            if (health < 0) health = 0; // Ensure health doesn't go below 0
            if (health == 0)
            {
                Respawn(); // Respawn if health reaches 0
            }
            healthText.text = "Health: " + health.ToString(); // Update health UI
        }

        if (other.CompareTag("PowerDown"))
        {
            health -= 10; // Decrease health by 10 when colliding with lavva
            Destroy(other.gameObject);
            if (health < 0) health = 0; // Ensure health doesn't go below 0
            if (health == 0)
            {
                Respawn(); // Respawn if health reaches 0
            }
            healthText.text = "Health: " + health.ToString(); // Update health UI
        }
        if (other.CompareTag("PowerUp"))
        {
            health += 10; // Decrease health by 10 when colliding with lavva
            Destroy(other.gameObject);
            if (health < 0) health = 0; // Ensure health doesn't go below 0
            if (health == 0)
            {
                Respawn(); // Respawn if health reaches 0
            }
            healthText.text = "Health: " + health.ToString(); // Update health UI
        }

        if (other.CompareTag("Laser"))
        {
            health -= 10; // Decrease health by 10 when colliding with lavva
            if (health < 0) health = 0; // Ensure health doesn't go below 0
            if (health == 0)
            {
                Respawn(); // Respawn if health reaches 0
            }
            healthText.text = "Health: " + health.ToString(); // Update health UI
        }
    }
    void UpdateCollectibleCount()
    {
        collectiblecount.text = "Collectible: " + collectible.ToString();
    }
    void UpdateHealthUI()
    {
        healthText.text = "Health: " + health.ToString();
    }
    void Respawn()
    {
        transform.position = spawnPoint.position;
        health = 100;
        UpdateHealthUI();
    }
    public int GetCount()
{
    return collectible;
}


}