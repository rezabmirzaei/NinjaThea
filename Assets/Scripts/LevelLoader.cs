using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] private Animator crossfadeAnimator;
    [SerializeField] private float transitionTime = 1f;

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
