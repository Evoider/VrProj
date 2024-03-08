using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class TorusGenerator : MonoBehaviour
{
    public int numSegments = 32;
    public int numSides = 16;
    public float majorRadius = 1.0f;
    public float minorRadius = 0.1f;
    public float edgeThickness = 0.1f;

    private void OnValidate()
    {
        GenerateTorus();
    }

    void Start()
    {
        GenerateTorus();
    }

    void GenerateTorus()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[numSegments * numSides];
        int[] triangles = new int[numSegments * numSides * 6];

        float deltaTheta = (2f * Mathf.PI) / numSegments;
        float deltaPhi = (2f * Mathf.PI) / numSides;

        int vertIndex = 0;
        int triIndex = 0;

        for (int i = 0; i < numSegments; i++)
        {
            float theta = i * deltaTheta;
            float cosTheta = Mathf.Cos(theta);
            float sinTheta = Mathf.Sin(theta);

            for (int j = 0; j < numSides; j++)
            {
                float phi = j * deltaPhi;
                float cosPhi = Mathf.Cos(phi);
                float sinPhi = Mathf.Sin(phi);

                float x = (majorRadius + minorRadius * cosPhi) * cosTheta;
                float y = minorRadius * sinPhi;
                float z = (majorRadius + minorRadius * cosPhi) * sinTheta;

                vertices[vertIndex] = new Vector3(x, y, z);

                if (i < numSegments - 1)
                {
                    if (j < numSides - 1)
                    {
                        triangles[triIndex] = vertIndex;
                        triangles[triIndex + 1] = vertIndex + numSides;
                        triangles[triIndex + 2] = vertIndex + 1;

                        triangles[triIndex + 3] = vertIndex + 1;
                        triangles[triIndex + 4] = vertIndex + numSides;
                        triangles[triIndex + 5] = vertIndex + numSides + 1;
                    }
                    else
                    {
                        triangles[triIndex] = vertIndex;
                        triangles[triIndex + 1] = vertIndex + numSides;
                        triangles[triIndex + 2] = vertIndex - numSides + 1;

                        triangles[triIndex + 3] = vertIndex - numSides + 1;
                        triangles[triIndex + 4] = vertIndex + numSides;
                        triangles[triIndex + 5] = vertIndex + 1;
                    }

                    triIndex += 6;
                }

                vertIndex++;
            }
        }

        // Adjuster les vertices pour l'épaisseur des bords
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = vertices[i].normalized * (majorRadius + edgeThickness);
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}