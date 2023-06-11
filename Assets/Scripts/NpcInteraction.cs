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
        // Instantiate the quest item in the scene
        Instantiate(questItemPrefab, transform.position, Quaternion.identity);

        // Display a message or UI feedback indicating the player received a quest
        Debug.Log("Quest received!");

        // Set questGiven flag to true
        questGiven = true;
    }

    private void InteractWithPlayer()
    {
        // Check if the quest is complete
        QuestSystem questSystem = FindObjectOfType<QuestSystem>();
        if (questSystem != null && questSystem.requiredItemCount > 0)
        {
            Debug.Log("You need to collect more items to complete the quest.");
        }
        else
        {
            Debug.Log("Quest completed! Interact with the capsule again to finish the quest.");
        }
    }
}