using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        string nivelACargar = SceneLoadManager.siguienteNivel;
        StartCoroutine(IniciarCarga(nivelACargar));
    }
    IEnumerator IniciarCarga(string nivel)
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nivel);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                animator.SetTrigger("FadeOut");
                StartCoroutine(ChangeScene(operation));
            }
            yield return null;
        }
    }

    IEnumerator ChangeScene(AsyncOperation operation)
    {
        yield return new WaitForSeconds(1.3f);
        operation.allowSceneActivation = true;
    }
}
