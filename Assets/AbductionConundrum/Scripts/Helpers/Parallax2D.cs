using UnityEngine;

public class Parallax2D : MonoBehaviour
{
  public Transform[] parallaxLayers; // Array of parallax layers
  public float[] parallaxSpeeds;      // Speed of each parallax layer

  private Vector3[] initialPositions; // Initial positions of the layers

  private void Start()
  {
    // Store the initial positions of the layers
    initialPositions = new Vector3[parallaxLayers.Length];
    for (int i = 0; i < parallaxLayers.Length; i++)
    {
      initialPositions[i] = parallaxLayers[i].position;
    }
  }

  private void Update()
  {
    for (int i = 0; i < parallaxLayers.Length; i++)
    {
      // Calculate the parallax effect by moving the layers based on the camera's movement
      float parallax = (initialPositions[i].x - Camera.main.transform.position.x) * parallaxSpeeds[i];

      // Apply the parallax effect to the layer's position
      Vector3 newPosition = new Vector3(initialPositions[i].x + parallax, parallaxLayers[i].position.y, parallaxLayers[i].position.z);
      parallaxLayers[i].position = newPosition;
    }
  }
}