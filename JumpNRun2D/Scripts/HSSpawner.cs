using UnityEngine;

public class HSSpawner : MonoBehaviour
{

    public GameObject[] HindernisPrefabs;
    public Transform HindernisSpawnpoint;
    void Start()
    {
        SpawnNext();
    }
    
    public void SpawnNext()
    {
     
        if (HindernisPrefabs.Length == 0 || HindernisSpawnpoint == null)
            return;


        int randomIndex = Random.Range(0, HindernisPrefabs.Length); 
        GameObject AusgewähltesHindernis = HindernisPrefabs[randomIndex];


        Instantiate(AusgewähltesHindernis, HindernisSpawnpoint.position, Quaternion.identity);
    }
}
