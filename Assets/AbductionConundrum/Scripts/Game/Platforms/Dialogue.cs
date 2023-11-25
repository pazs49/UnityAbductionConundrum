using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
  public string message;
  public GameObject dialogueCanvas;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      dialogueCanvas.SetActive(true);
      dialogueCanvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = message;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (dialogueCanvas.activeSelf)
    {
      dialogueCanvas.SetActive(false);
    }
  }

}
