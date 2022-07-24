using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{

    [SerializeField] private Animator crossfadeAnimator;
    [SerializeField] private float transitionTime = 2f;

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadLevelByName(levelName));
    }

    IEnumerator LoadLevelByName(string levelName)
    {
        crossfadeAnimator.SetTrigger("Crossfade");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }
}
