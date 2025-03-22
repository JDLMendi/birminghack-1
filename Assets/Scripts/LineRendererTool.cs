using UnityEngine;
using UnityEditor;

public class LineRendererTool : EditorWindow
{
    private Transform object1;
    private Transform object2;

    [MenuItem("Tools/Line Renderer Tool")]
    public static void ShowWindow()
    {
        GetWindow<LineRendererTool>("Line Renderer Tool");
    }

    void OnGUI()
    {
        GUILayout.Label("Select Objects to Connect", EditorStyles.boldLabel);
        object1 = (Transform)EditorGUILayout.ObjectField("Object 1", object1, typeof(Transform), true);
        object2 = (Transform)EditorGUILayout.ObjectField("Object 2", object2, typeof(Transform), true);

        if (GUILayout.Button("Draw Line"))
        {
            CreateLine();
        }
    }

    void CreateLine()
    {
        if (object1 == null || object2 == null)
        {
            Debug.LogWarning("Please assign both objects before drawing a line.");
            return;
        }

        GameObject lineObject = new GameObject("LineRendererObject");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;

        // Ensure the line appears behind other objects in a 2D scene
        lineRenderer.sortingOrder = -10; // Lower sortingOrder value makes it render behind

        lineRenderer.SetPosition(0, object1.position + new Vector3(0, 0, 0.25f));
        lineRenderer.SetPosition(1, object2.position + new Vector3(0, 0, 0.25f));
    }
}
