using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Display UI message or feedback indicating the player can interact with the item
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide UI message or feedback indicating the player can interact with the item
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            // Notify the quest system that the player has collected an item
            QuestSystem questSystem = FindObjectOfType<QuestSystem>();
            if (questSystem != null)
            {
                questSystem.CollectItem();
            }

            // Remove or disable the quest item from the scene
            gameObject.SetActive(false);
        }
    }
}