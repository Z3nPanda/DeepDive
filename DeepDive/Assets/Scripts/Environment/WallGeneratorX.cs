using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class WallGeneratorX : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    private bool draw = false;

    public int ySize = 150;
    public int xSize = 250;

    [SerializeField] private float xMod = .2f;
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
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];
        
        // Creates an x by z plane of vertices
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                // PerlinNoise sets the noise for the occurence of landmass shapes to establish landmasses of various heights on the y axis
                float z = Mathf.PerlinNoise(x * xMod, y * yMod) * externalMod;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        // Connects our vertices with triangles forming squares of two inner triangles until the plane is filled
        triangles = new int[(xSize * ySize * 6)];

        int vert = 0;
        int tris = 0;
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        // Code for creating a texture for our mesh
        uvs = new Vector2[vertices.Length];
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float) x / xSize, (float) y / ySize);
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
