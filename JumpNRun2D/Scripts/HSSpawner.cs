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
        // Falls wir vergessen haben, Vorlagen einzutragen, machen wir lieber nichts, sonst stürzt Unity ab
        if (HindernisPrefabs.Length == 0 || HindernisSpawnpoint == null)
            return;


        int randomIndex = Random.Range(0, HindernisPrefabs.Length); //RANDOM.RANGE (0) damit die random zählung bei 0 beginnt
        GameObject AusgewähltesHindernis = HindernisPrefabs[randomIndex];

        // "Instantiate" bedeutet: Erschaffe eine Kopie der Vorlage am Spawn-Punkt!
        Instantiate(AusgewähltesHindernis, HindernisSpawnpoint.position, Quaternion.identity);
    }
}
