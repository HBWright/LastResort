//chatgpt
using UnityEngine;
using System.Collections.Generic;

public class AvalancheSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public int numberOfSpheres = 20;
    public float minDiameter = 0.5f;
    public float maxDiameter = 2f;
    public float spawnWidth = 10f;
    public Axis spawnAxis = Axis.X;

    [Header("Movement Settings")]
    public Vector3 movementDirection = new Vector3(0, -1, 1);
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float despawnDistance = 50f;

    [Header("Sphere Settings")]
    public Material whiteMaterial;

    public enum Axis { X, Y, Z }

    // Internal data structure
    private class SphereData
    {
        public Transform transform;
        public float speed;
        public Vector3 startPosition;
    }

    private List<SphereData> activeSpheres = new List<SphereData>();

    void Start()
    {
        SpawnSpheres();
    }

    void Update()
    {
        MoveAndCullSpheres();
    }

    void SpawnSpheres()
    {
        for (int i = 0; i < numberOfSpheres; i++)
        {
            float diameter = Random.Range(minDiameter, maxDiameter);
            Vector3 position = transform.position;

            float offset = Random.Range(-spawnWidth / 2f, spawnWidth / 2f);

            /*switch (spawnAxis)
            {
                case Axis.X: position.x += offset; break;
                case Axis.Y: position.y += offset; break;
                case Axis.Z: position.z += offset; break;
            }*/
            Vector3 localOffset = Vector3.zero;
            switch (spawnAxis)
            {
                case Axis.X: localOffset = transform.right * offset; break;
                case Axis.Y: localOffset = transform.up * offset; break;
                case Axis.Z: localOffset = transform.forward * offset; break;
            }

            position += localOffset;
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = position;
            sphere.transform.localScale = Vector3.one * diameter;

            // Assign material
            if (whiteMaterial != null)
                sphere.GetComponent<Renderer>().material = whiteMaterial;
            else
                sphere.GetComponent<Renderer>().material.color = Color.white;

            // Remove collider (optional)
            Destroy(sphere.GetComponent<Collider>());

            // Store data
            SphereData data = new SphereData
            {
                transform = sphere.transform,
                speed = Random.Range(minSpeed, maxSpeed),
                startPosition = sphere.transform.position
            };

            activeSpheres.Add(data);
        }
    }

    void MoveAndCullSpheres()
    {
        Vector3 direction = movementDirection.normalized;

        // Use a temp list to avoid modifying collection during iteration
        List<SphereData> toRemove = new List<SphereData>();

        foreach (SphereData data in activeSpheres)
        {
            data.transform.position += direction * data.speed * Time.deltaTime;

            float traveledDistance = Vector3.Distance(data.startPosition, data.transform.position);
            if (traveledDistance > despawnDistance)
            {
                Destroy(data.transform.gameObject);
                toRemove.Add(data);
            }
        }

        // Clean up removed spheres
        foreach (SphereData data in toRemove)
        {
            activeSpheres.Remove(data);
        }

    }
}
