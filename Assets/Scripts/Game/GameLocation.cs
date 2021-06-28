using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Game))]

public class GameLocation : MonoBehaviour
{
    [SerializeField] private Vector2 _min;
    [SerializeField] private Vector2 _max;

    [SerializeField] private List<GameObject> _points;


    private List<Transform> _spawnedPoints;
    private List<ScorePoint> _scorePoints;

    private Slime _slime;

    private void Start()
    {
        _spawnedPoints = new List<Transform>();
        _slime = FindObjectOfType<Slime>();
        SpawnPoints();
    }

    private void Update()
    {
        _scorePoints = FindObjectsOfType<ScorePoint>().ToList();
        if (_scorePoints.Count == 0)
        {
            RestartGame();
        }
    }

    private void SpawnPoints()
    {
        foreach (GameObject g in _points)
        {
            int spawnCount = Random.Range(1, 4);
            for (int i = 0; i < spawnCount; i++)
            {
                Vector2 spawnPos;
                do
                {
                    spawnPos = GetSpawnPosition();
                }
                while (Vector2.Distance(_slime.transform.position, spawnPos) < 8 && Vector2.Distance(spawnPos, GetClosestPoint(_spawnedPoints).position) < 5);
                _spawnedPoints.Add(Instantiate(g, spawnPos, Quaternion.identity).transform);
            }
        }
    }

    private void ClearGameField()
    {
        foreach (Transform g in _spawnedPoints)
        {
            if (g != null)
                Destroy(g.gameObject, 0);
        }
        _spawnedPoints = new List<Transform>();
    }

    private Vector2 GetSpawnPosition()
    {
        float xPos = Random.Range(_min.x, _max.x);
        float yPos = Random.Range(_min.y, _max.y);
        Vector2 spawnPos = new Vector2(xPos, yPos);
        return spawnPos;
    }

    private Transform GetClosestPoint(List<Transform> points)
    {
        if (points.Count == 0)
            return transform;

        Transform closestPoint = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in points)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestPoint = potentialTarget;
            }
        }

        return closestPoint;
    }

    public void RestartGame()
    {
        ClearGameField();
        SpawnPoints();
    }
}
