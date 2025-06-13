using TMPro;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public CollectibleCollection ineedtocollect;
    public int requiredCollectibles = 2;
    private bool playerInRange = false;
    private int collectibleCount = 0;


    [Header("UI")]
    public TextMeshProUGUI doorPrompt; // This is the UI Text you assign manually in the Inspector

    void Start()
    {
        if (doorPrompt != null)
            doorPrompt.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player") && doorPrompt != null)
    {
        CollectibleCollection collectible = other.GetComponent<CollectibleCollection>();
        if (collectible != null)
        {
            collectibleCount = collectible.GetCount();
        }
        playerInRange = true;
        doorPrompt.text = "Press E to open";
        doorPrompt.gameObject.SetActive(true);
    }
}

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && doorPrompt != null)
        {
            playerInRange = false;
            doorPrompt.gameObject.SetActive(false);
        }
    }

   void Update()
{
    if (playerInRange && Input.GetKeyDown(KeyCode.E) && doorPrompt != null)
    {
        CollectibleCollection collectible = ineedtocollect;
        if (collectible != null)
        {
            collectibleCount = collectible.GetCount();
        }

        if (collectibleCount >= requiredCollectibles)
        {
            doorPrompt.text = $"{collectibleCount}/{requiredCollectibles} collectibles found. Thank you!";
            doorPrompt.gameObject.SetActive(false); // Hide prompt
            Destroy(gameObject); // Destroy the door
        }
        else
        {
            doorPrompt.text = $"{collectibleCount}/{requiredCollectibles} found. Go find them!";
        }
    }
}

    public void SetCollected(int count)
    {
        collectibleCount += count;
    }

    
    
}
