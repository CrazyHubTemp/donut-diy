using Dreamteck.Splines;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    public class ChurrosGenerator : MonoBehaviour
    {
        private SplineComputer _splineComputer;
        public SplineComputer SplineComputer => _splineComputer == null ? _splineComputer = GetComponent<SplineComputer>() : _splineComputer;

        [SerializeField] private LayerMask spawnableLayer;

        private Vector3 _lastSpawnPoint = Vector3.negativeInfinity;

        private const float MIN_SPAWN_OFFSET = 0.2f;
        private const int MAX_SPAWN_SPLINE_POINT = 30;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                CheckSpawnPosition();
            }
        }

        private void CheckSpawnPosition()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000, spawnableLayer))
            {
                if (Vector3.Distance(hit.point, _lastSpawnPoint) > MIN_SPAWN_OFFSET)
                    SpawnSplinePoint(hit.point);
            }
        }

        private void SpawnSplinePoint(Vector3 spawnPosition)
        {
            if (!CanSpawn())
                return;

            Debug.Log(spawnPosition);
            _lastSpawnPoint = spawnPosition;
        }

        private bool CanSpawn()
        {
            if (SplineComputer.pointCount >= MAX_SPAWN_SPLINE_POINT)
                return false;

            return true;
        }
    }
}