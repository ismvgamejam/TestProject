using TMPro;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject player;
    public TMP_Text interactionText;

    private bool interactionEnabled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            interactionEnabled = true;
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            interactionEnabled = false;
            interactionText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (interactionEnabled && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithPlayer();
        }
    }

    private void InteractWithPlayer()
    {
        // TODO: Implement your interaction logic here
        Debug.Log("Interaction with player activated!");
    }
}