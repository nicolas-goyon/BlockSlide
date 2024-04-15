using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnInterval = 1.0f;

    private float timeLeft = 1.0f;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private string rowPrefabPath = "Prefabs/Rows";

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float destroyMark = -10.0f;

    private List<GameObject> spawnList = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (spawnInterval <= 0) {
            Debug.LogError("Spawn interval must be greater than 0");
            return;
        }
        if (rowPrefabPath == null || rowPrefabPath.Length == 0) {
            Debug.LogError("Row prefab path must be set");
            return;
        }

        spawnList = LoadPrefabs(rowPrefabPath);

        if (spawnList.Count == 0) {
            Debug.LogError("No prefabs found in path: " + rowPrefabPath);
            return;
        }

        timeLeft = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState == GameState.GameOver) {
            return;
        }
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0) {
            timeLeft = spawnInterval;
            SpawnRow();
        }
    }

    private void SpawnRow() {
        GameObject row = Instantiate(RowPrefab, spawnPoint.transform.position, Quaternion.identity);

        RowMovements rowMovements = row.GetComponent<RowMovements>();

        rowMovements.SetSpeed(speed);
        rowMovements.SetDestroyMark(destroyMark);
    }


    private List<GameObject> LoadPrefabs(string folderPath) {
        // Check if path is valid
        if (folderPath == null || folderPath.Length == 0) {
            Debug.LogError("Invalid folder path");
            return new List<GameObject>();
        }



        List<GameObject> prefabs = new();
        GameObject[] objs = Resources.LoadAll<GameObject>(folderPath);
        foreach (GameObject obj in objs) {
            prefabs.Add(obj);
        }
        return prefabs;
    }

    private GameObject RowPrefab {
        get {
            return spawnList[Random.Range(0, spawnList.Count)];
        }
    }


}
