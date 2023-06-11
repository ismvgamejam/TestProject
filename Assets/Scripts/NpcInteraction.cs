using UnityEngine;
using UnityEngine.UI;

public class NpcInteraction : MonoBehaviour
{
    public GameObject player;
    //public Text interactionText;
    public GameObject questItemPrefab; // Prefab for the quest item

    private bool interactionEnabled = false;
    private bool questGiven = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            interactionEnabled = true;
            //interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            interactionEnabled = false;
            //interactionText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (interactionEnabled && Input.GetKeyDown(KeyCode.E))
        {
            if (!questGiven)
            {
                GiveQuest();
            }
            else
            {
                InteractWithPlayer();
            }
        }
    }

    private void GiveQuest()
    {
        // Clear any existing quest items in the scene
        QuestItem[] existingQuestItems = FindObjectsOfType<QuestItem>();
        foreach (QuestItem questItem in existingQuestItems)
        {
            Destroy(questItem.gameObject);
        }

        // Get the player's position
        Vector3 playerPosition = player.transform.position;

        // Instantiate the required number of quest items in positions near the player
        for (int i = 0; i < QuestSystem.Instance.requiredItemCount; i++)
        {
            Vector3 randomOffset = GetRandomOffset();
            Vector3 spawnPosition = playerPosition + randomOffset;
            Instantiate(questItemPrefab, spawnPosition, Quaternion.identity);
        }

        // Display a message or UI feedback indicating the player received a quest
        Debug.Log("Quest received!");

        // Set questGiven flag to true
        questGiven = true;

        // Start the quest in the QuestSystem
        QuestSystem.Instance.StartQuest();
    }

    private void InteractWithPlayer()
    {
        // Check if the quest is complete
        if (QuestSystem.Instance.HasQuest())
        {
            if (QuestSystem.Instance.requiredItemCount > 0 
                && QuestSystem.Instance.CollectedAmount() < QuestSystem.Instance.requiredItemCount)
            {
                Debug.Log("You need to collect more items to complete the quest.");
            }
            else if (QuestSystem.Instance.CollectedAmount() == QuestSystem.Instance.requiredItemCount)
            {
                Debug.Log("Quest finished! Here is your reward.");
                Debug.Log("You received 0.000000001 bitcoin.");
            }
        }
    }

    private Vector3 GetRandomOffset()
    {
        // Generate a random offset within a specific range
        float offsetX = Random.Range(-5f, 5f);
        float offsetZ = Random.Range(-5f, 5f);
        Vector3 randomOffset = new Vector3(offsetX, 0.5f, offsetZ);
        return randomOffset;
    }
}