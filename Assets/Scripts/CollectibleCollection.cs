using UnityEngine;
using TMPro;

public class CollectibleCollection : MonoBehaviour
{
    public int collectible = 0;
    private int health = 100;
    public TextMeshProUGUI collectiblecount;
    public TextMeshProUGUI healthText;
    public Transform spawnPoint;
    bool allCollectiblesCollect;

    private float damageCooldown = 1f; // Cooldown time in seconds
    private float lastDamageTime = -1f; // Last time damage or healing was applied

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

            // Optional: disable collider + renderer immediately to prevent re-trigger
            other.GetComponent<Collider>().enabled = false;
            if (other.GetComponent<MeshRenderer>() != null)
                other.GetComponent<MeshRenderer>().enabled = false;

            Destroy(other.gameObject); // Still destroy it
            UpdateCollectibleCount();
            Debug.Log("Collectibles Collected : " + collectible);
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Check cooldown
        if (Time.time - lastDamageTime < damageCooldown) return;

        if (other.CompareTag("Lava"))
        {
            health -= 10;
            lastDamageTime = Time.time;
        }

        if (other.CompareTag("PowerDown"))
        {
            health -= 10;
            Destroy(other.gameObject);
            lastDamageTime = Time.time;
        }

        if (other.CompareTag("PowerUp"))
        {
            health += 10;
            Destroy(other.gameObject);
            lastDamageTime = Time.time;
        }

        if (other.CompareTag("Laser"))
        {
            health -= 10;
            lastDamageTime = Time.time;
        }

        // Clamp health and check for respawn
        if (health < 0) health = 0;
        if (health == 0)
        {
            Respawn();
        }

        UpdateHealthUI();
    }

    void UpdateCollectibleCount()
    {
        collectiblecount.text = "Collectible: " + collectible.ToString();
        if (collectible == 5) ;
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
    void ApplyBulletDamage(float amount)
    {
        health -= Mathf.RoundToInt(amount);
        if (health < 0) health = 0;
        if (health == 0)
        {
            Respawn();
        }
        UpdateHealthUI();
    }

    public int GetCount()
    {
        return collectible;
    }

    [SerializeField] GameObject congratsScreen;

    [SerializeField] TMP_Text congratsScoreDisplay;

    public void Win()
    {
        if(allCollectiblesCollect)
        {
            congratsScreen.SetActive(true);
            Time.timeScale = 0f;
            congratsScoreDisplay.text = ("Score: " + health);
        }
    }
}
