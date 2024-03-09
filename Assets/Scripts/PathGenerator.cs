using UnityEngine;

public class PathManager : MonoBehaviour
{
    // Game object prefab to spawn
    public GameObject pathPrefab;

    // Length of each path segment
    public float pathSegmentLength = 200f;

    // Total length of the path
    public float totalPathLength = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate the number of segments needed based on total path length and segment length
        int numSegments = Mathf.FloorToInt(totalPathLength / pathSegmentLength);

        // Spawn the path segments
        for (int i = 0; i < numSegments; i++)
        {
            // Calculate the position for the current path segment
            Vector3 spawnPosition = new Vector3(0f, 0f, (i + 1) * pathSegmentLength);

            // Instantiate the path prefab at the calculated position
            Instantiate(pathPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
