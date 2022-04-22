using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WallGeneratorZ : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    private bool draw = false;

    public int ySize = 150;
    public int zSize = 250;

    [SerializeField] private float zMod = .2f;
    [SerializeField] private float yMod = .2f;
    [SerializeField] private float externalMod = 1f;

    void Start()
    {
        // Create our new mesh and store it in the mesh filter
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        // Actually create the shapes
        CreateShape();
        UpdateMesh();
    }

    // Function for generating landscape mesh
    void CreateShape()
    {
        vertices = new Vector3[(zSize + 1) * (ySize + 1)];
        
        // Creates a y by z plane of vertices
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int z = 0; z <= zSize; z++)
            {
                // PerlinNoise sets the noise for the occurence of landmass shapes to establish landmasses of various heights on the y axis
                float x = Mathf.PerlinNoise(z * zMod, y * yMod) * externalMod;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        // Connects our vertices with triangles forming squares of two inner triangles until the plane is filled
        triangles = new int[(zSize * ySize * 6)];

        int vert = 0;
        int tris = 0;
        for (int y = 0; y < ySize; y++)
        {
            for (int z = 0; z < zSize; z++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + zSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + zSize + 1;
                triangles[tris + 5] = vert + zSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        // Code for creating a texture for our mesh
        uvs = new Vector2[vertices.Length];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int z = 0; z <= zSize; z++)
            {
                uvs[i] = new Vector2((float) z / zSize, (float) y / ySize);
                i++;
            }
        }

    }

    void UpdateMesh()
    {
        // Clear any previous data
        mesh.Clear();

        // Update our mesh vertices and triangles
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();

        // Adds mesh collider
        mesh.RecalculateBounds();
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }

        if (draw)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], .05f);
            }
        }
    }
}
