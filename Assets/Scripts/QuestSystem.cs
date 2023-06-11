using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public int requiredItemCount = 5; // Number of items required to complete the quest
    private int collectedItemCount = 0; // Number of items collected by the player

    public void CollectItem()
    {
        collectedItemCount++;

        // Check if the player has collected enough items to complete the quest
        if (collectedItemCount >= requiredItemCount)
        {
            Debug.Log("Quest completed!");
        }
    }
}