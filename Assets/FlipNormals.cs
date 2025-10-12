using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class FlipMeshNormals : MonoBehaviour
{
    [ContextMenu("Flip Normals")]
    void FlipNormals()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null)
        {
            Debug.LogError("Missing MeshFilter or Mesh.");
            return;
        }

        Mesh mesh = meshFilter.sharedMesh;

        // Flip the normals
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
        mesh.normals = normals;

        // Flip the triangle winding order
        for (int subMesh = 0; subMesh < mesh.subMeshCount; subMesh++)
        {
            int[] triangles = mesh.GetTriangles(subMesh);
            for (int i = 0; i < triangles.Length; i += 3)
            {
                // Swap the first and third index to flip the winding
                int temp = triangles[i];
                triangles[i] = triangles[i + 2];
                triangles[i + 2] = temp;
            }
            mesh.SetTriangles(triangles, subMesh);
        }

        Debug.Log("Normals flipped for mesh: " + mesh.name);
    }
}
