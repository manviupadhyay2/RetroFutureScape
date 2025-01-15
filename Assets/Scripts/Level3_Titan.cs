using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Level3_Titan : MonoBehaviour
{
    [Header("Titans Health and Damage")]
    private float titanHealth = 400f;
    private float presentHealth;

    [Header("Titan Things")]
    public NavMeshAgent titanAgent;
    public Transform LookPoint;
    public Transform playerBody;
    public LayerMask PlayerLayer;

    [Header("Titan Guarding Var")]
    public GameObject[] walkPoints;
    int currentTitanPosition = 0;
    public float titanSpeed;
    float walkingpointRadius = 2;

    [Header("Titan Animation")]
    public Animator anim;

    [Header("QuestionCanvas")]
    public GameObject questionCanvas;

    private bool isDead = false;
    bool isQuestionAnswered = false;

    private void Awake()
    {
        presentHealth = titanHealth;
        titanAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

    }

    public void titanHitDamage(float takeDamage)
    {
        if (!isDead) // Check if the Titan is not already dead.
        {
            presentHealth -= takeDamage;

            if (presentHealth <= 0)
            {
                isDead = true; // Set the flag to mark the Titan as dead.
                anim.SetBool("Walking", false);
                anim.SetBool("Scream", true);
                TitanDie();
            }
        }
    }

    private void TitanDie()
    {
        anim.SetBool("Death", true);

        // Delay showing the question canvas
        StartCoroutine(ShowQuestionAfterDeath());
    }

    private IEnumerator ShowQuestionAfterDeath()
    {
        yield return new WaitForSeconds(7.0f); // Adjust the delay time as needed

        // Now activate the question canvas
        questionCanvas.SetActive(true);

        // Unlock the cursor and make it visible after a delay
        StartCoroutine(ShowCursorAfterDeath());

        Level3_Scoring scoringScript = FindObjectOfType<Level3_Scoring>();
        if (scoringScript != null)
        {
            scoringScript.IncreaseScore(5); // Increase the score by 5 when a titan is killed.
        }

        Level3_QuestionManager questionManager = FindObjectOfType<Level3_QuestionManager>();
    }

    private IEnumerator ShowCursorAfterDeath()
    {
        yield return new WaitForSeconds(2.0f); // Adjust the delay time as needed
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible

        // Optionally, add code here for any additional actions you want to perform when the cursor is made visible.
    }


}
