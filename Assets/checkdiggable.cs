using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class checkdiggable : MonoBehaviour
{
    public GameObject digSpot;
    public GameObject chest;
    public float moveDistanceLevelOne = 2f; // Adjust this value for the desired height per movement in level one
    public float moveDistanceLevelTwo = 0.67f; // Adjust this value for the desired height per movement in level two
    public float moveDuration = 1f;

    private bool isMoving = false;
    private int digCounter = 0;
    private bool isLevelOne = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving && other.CompareTag("DiggableCube"))
        {
            Debug.Log(other.transform.tag);

            digCounter++;

            // Move the chest on each dig
            StartCoroutine(MoveChest());
            
            // Start the fade out and load level coroutine on the third dig
            if (digCounter >= 3)
            {
                Debug.Log("Moved");
                StartCoroutine(FadeOutAndLoadLevel());
            }
        }
    }

    private IEnumerator MoveChest()
    { 
        Vector3 initialPosition = chest.transform.position;
        float currentMoveDistance = isLevelOne ? moveDistanceLevelOne : moveDistanceLevelTwo;
        Vector3 targetPosition = initialPosition + new Vector3(0f, currentMoveDistance, 0f); // Adjust the moveDistance

        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            chest.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        chest.transform.position = targetPosition;

        isMoving = false;
    }

    private IEnumerator FadeOutAndLoadLevel()
    {
        // TODO: Implement screen fade out effect here
        Debug.Log("Fading out...");

        yield return new WaitForSeconds(2f); // Placeholder delay for fade out effect

        SceneManager.LoadScene("LevelTwo_Vulcano");
    }
}
