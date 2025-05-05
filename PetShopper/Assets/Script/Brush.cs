using UnityEngine;

public class Brush : MonoBehaviour
{
    public GameObject triggerPrefab;      // Prefab with trigger collider & detection script
    public float spawnRate = 0.05f;       // Time between spawns
    public float triggerLifetime = 0.2f;  // How long each trigger exists
    public float brushDistanceFromCamera = 10f;

    private float spawnTimer;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Mouse 1 held down
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                SpawnBrushTrigger();
                spawnTimer = spawnRate;
            }
        }
        else
        {
            spawnTimer = 0f;
        }
    }

    void SpawnBrushTrigger()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = brushDistanceFromCamera;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        GameObject trigger = Instantiate(triggerPrefab, worldPos, Quaternion.identity);
        Destroy(trigger, triggerLifetime);
    }
}