using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{

    [SerializeField] private Animator crossfadeAnimator;
    [SerializeField] private float transitionTime = 2f;

    public void LoadNextStage()
    {
        StartCoroutine(LoadNextStageByIndex(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadStageByIndex(int sceneIndex)
    {
        StartCoroutine(LoadNextStageByIndex(sceneIndex));
    }

    IEnumerator LoadNextStageByIndex(int sceneIndex)
    {
        crossfadeAnimator.SetTrigger("Crossfade");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
