using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [Header("Prefabs")]
    public List<GameObject> listOfEasyBlocks;
    public Dictionary<int, Pool> easyDictionary;
    public List<GameObject> listOfMediumBlocks;
    public Dictionary<int, Pool> mediumDictionary;
    public List<GameObject> listOfHardBlocks;
    public Dictionary<int, Pool> hardDictionary;

    [Header("Settings")]
    public float minEasyDistanceInX;
    public float maxEasyDistanceInX;
    private Vector3 currentEasyPosition = Vector3.zero;
    [Space]
    public float minMediumDistanceInX;
    public float maxMediumDistanceInX;
    private Vector3 currentMediumPosition = Vector3.zero;
    [Space]
    public float minHardDistanceInX;
    public float maxHardDistanceInX;
    private Vector3 currentHardPosition = Vector3.zero;
    [Space]
    public float timeToSpawn;
    public float timeToDestroy;

    private Difficulty difficulty = Difficulty.easy;
    private enum Difficulty { easy, medium, hard }

    #region Unity Events

    private void Start()
    {
        easyDictionary = new Dictionary<int, Pool>();
        StartDictionary(listOfEasyBlocks, easyDictionary);
        
        StartCoroutine(SpawnNewParts());
    }

    #endregion
    
    #region Helpers

    private void StartDictionary(List<GameObject> listOfObjects, Dictionary<int, Pool> dictionary)
    {

        for (int i = 0; i < listOfObjects.Count; i++)
        {
            Pool pool = new Pool();
            pool.NewPool(listOfObjects[i]);
            dictionary.Add(i, pool);
        }
    }

    IEnumerator SpawnNewParts()
    {

        switch (difficulty)
        {
            case Difficulty.easy:
                currentEasyPosition = new Vector3(currentEasyPosition.x + Random.Range(minEasyDistanceInX, maxEasyDistanceInX),
                    0f, 0f);
                CreatePartFromDictionary(currentEasyPosition, easyDictionary);
                break;
            case Difficulty.medium:
                break;
            case Difficulty.hard:
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(timeToSpawn);

        StartCoroutine(SpawnNewParts());
    }

    private void CreatePartFromDictionary(Vector3 newPosition, Dictionary<int, Pool> dictionary)
    {
        int index = Random.Range(0, dictionary.Count);
        GameObject newPart = dictionary[index].NewObject(newPosition);
        StartCoroutine(DespawnParts(dictionary[index], newPart));
    }

    IEnumerator DespawnParts(Pool pool, GameObject part)
    {
        yield return new WaitForSeconds(timeToDestroy);
        pool.RemoveObject(part);
    }

    #endregion

}
