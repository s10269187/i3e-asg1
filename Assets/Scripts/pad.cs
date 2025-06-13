using UnityEngine;

public class pad : MonoBehaviour
{

    public Transform spawnPoint;
    public string hazardTag = "Hazard";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(hazardTag))
        {
            ResetPlayer();
        }

    }

    void ResetPlayer()
    {
        transform.position = spawnPoint.position;

        // Optional: reset Rigidbody velocity if needed
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        Debug.Log("Player reset to spawn point.");
    }
}
