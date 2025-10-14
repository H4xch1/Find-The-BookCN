using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [Header("Scene Loading")]
    [SerializeField] private string nextSceneName = "NameOfYourNextScene";
    
    [Header("Activation Requirement")]
    [Tooltip("The number of coins required to activate this trigger.")]
    [SerializeField] private int requiredCoinCount = 8;
    
    // Components to control the visibility/trigger area
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // Get references to the components on this object
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Start deactivated (invisible and non-functional)
        SetTriggerActive(false);

        // OPTIONAL: Subscribe to an event, or more simply, use Update/LateUpdate.
    }

    void Update()
    {
        // Only check if the trigger is currently inactive
        if (boxCollider != null && !boxCollider.enabled)
        {
            // Check if the requirement is met
            if (coinmanagement.Instance.coinCount >= requiredCoinCount)
            {
                SetTriggerActive(true);
                Debug.Log("Coin requirement met! Scene Trigger is now active.");
            }
        }
    }

    private void SetTriggerActive(bool isActive)
    {
        // Make the visual component appear/disappear
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = isActive;
        }

        // Enable/disable the actual trigger area
        if (boxCollider != null)
        {
            boxCollider.enabled = isActive;
        }
    }


    // This function is still called when an object enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // The BoxCollider2D is only enabled if the coins are met, 
        // but we check the tag for safety.
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger. Loading scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }
}