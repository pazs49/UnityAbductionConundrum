using UnityEditor;
using UnityEngine;

public class PrefabInstantiatorWindow : EditorWindow
{
  [SerializeField]
  private GameObject[] prefabs;
  private int selectedPrefabIndex = 0;

  [MenuItem("Window/Prefab Instantiator")]
  static void ShowWindow()
  {
    GetWindow<PrefabInstantiatorWindow>("Prefab Instantiator");
  }

  void OnGUI()
  {
    GUILayout.Label("Select a prefab to instantiate:");

    // Drag and drop multiple prefabs into the array
    SerializedObject serializedObject = new SerializedObject(this);
    SerializedProperty prefabArray = serializedObject.FindProperty("prefabs");
    EditorGUILayout.PropertyField(prefabArray, true);

    serializedObject.ApplyModifiedProperties();

    // Display a dropdown to select which prefab to instantiate
    selectedPrefabIndex = EditorGUILayout.Popup("Selected Prefab", selectedPrefabIndex, GetPrefabNames());

    if (GUILayout.Button("Instantiate Selected Prefab"))
    {
      InstantiatePrefab(selectedPrefabIndex);
    }
  }

  void InstantiatePrefab(int index)
  {
    if (index >= 0 && index < prefabs.Length && prefabs[index] != null)
    {
      // Instantiate the selected prefab at the Scene view's origin
      GameObject instantiatedPrefab = Instantiate(prefabs[index], new Vector3(GetCenterOfScreen().x,
       GetCenterOfScreen().y, 0), Quaternion.identity);
      Selection.activeGameObject = instantiatedPrefab;
    }
    else
    {
      Debug.LogError("Invalid prefab selection");
    }
  }

  Vector3 GetCenterOfScreen()
  {
    // Get the center of the screen in pixels
    Vector3 screenCenterInPixels = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);

    // Convert the screen center to a point in the scene
    Ray ray = HandleUtility.GUIPointToWorldRay(screenCenterInPixels);
    RaycastHit hit;
    Vector3 centerOfScreenInScene = ray.origin;

    return centerOfScreenInScene;
  }

  string[] GetPrefabNames()
  {
    if (prefabs != null && prefabs.Length > 0)
    {
      string[] prefabNames = new string[prefabs.Length];
      for (int i = 0; i < prefabs.Length; i++)
      {
        prefabNames[i] = (prefabs[i] != null) ? prefabs[i].name : "Missing Prefab";
      }
      return prefabNames;
    }
    return new string[] { "No Prefabs" };
  }
}