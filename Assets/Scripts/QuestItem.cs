using UnityEngine;

public class QuestItem : MonoBehaviour
{
    private bool isGathered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && QuestSystem.Instance.HasQuest())
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
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && QuestSystem.Instance.HasQuest() && !isGathered)
        {
            // Notify the quest system that the player has collected an item
            QuestSystem.Instance.CollectItem();

            // Set the item as gathered to prevent further collection
            isGathered = true;

            // Remove or disable the quest item from the scene
            gameObject.SetActive(false);
        }
    }
}