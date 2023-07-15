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

        private const float MIN_SPAWN_DISTANCE = 0.2f;
        private const float MAX_SPAWN_DISTANCE = 0.4f;

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
                if (IsFirstPoint())
                {
                    SpawnSplinePoint(hit.point);
                    return;
                }

                float pointDistance = Vector3.Distance(hit.point, _lastSpawnPoint);

                if (pointDistance > MIN_SPAWN_DISTANCE && pointDistance < MAX_SPAWN_DISTANCE)
                    SpawnSplinePoint(hit.point);
            }
        }

        private void SpawnSplinePoint(Vector3 spawnPosition)
        {
            if (!CanSpawn())
                return;

            _lastSpawnPoint = spawnPosition;
            Debug.Log(spawnPosition);
            SplinePoint newPoint = new(spawnPosition);
            SplineComputer.SetPoint(SplineComputer.pointCount, newPoint);
            SetMeshCount();
        }

        private void SetMeshCount()
        {
            GetComponent<SplineMesh>().GetChannel(0).count = SplineComputer.pointCount * 10;
        }

        private bool CanSpawn()
        {
            if (SplineComputer.pointCount >= MAX_SPAWN_SPLINE_POINT)
                return false;

            return true;
        }

        private bool IsFirstPoint()
        {
            return SplineComputer.pointCount == 0;
        }
    }
}