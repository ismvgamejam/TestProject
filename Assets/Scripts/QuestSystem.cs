using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem Instance { get; private set; }

    public int requiredItemCount = 5; // Number of items required to complete the quest
    private int collectedItemCount = 0; // Number of items collected by the player
    private bool hasQuest = false; // Flag indicating if the player has the quest

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartQuest()
    {
        hasQuest = true;
        collectedItemCount = 0;
        Debug.Log("Quest started!");
    }

    public void CollectItem()
    {
        if (hasQuest)
        {
            collectedItemCount++;
            Debug.Log($"Amount: {Instance.CollectedAmount()}");
            // Check if the player has collected enough items to complete the quest
            if (collectedItemCount >= requiredItemCount)
            {
                Debug.Log("Quest completed!");
            }
        }
    }

    public int CollectedAmount() => collectedItemCount;

    public bool HasQuest()
    {
        return hasQuest;
    }
}