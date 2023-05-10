using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TriangleGenerator : MonoBehaviour          //Thanks to Freya Holmer and her Youtube Channel Contents.
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();

        var localScale = transform.localScale;
        localScale.x = 0.5f;
        transform.localScale = localScale;
    }

    private void CreateShape()
    {
        vertices = new Vector3[]
        {
            new Vector3(0, 0, 0),
            new Vector3(0.5f, 0.5f, 0),
            new Vector3(1, 0, 0)
        };

        triangles = new int[]
        {
            0, 1, 2
        };
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}