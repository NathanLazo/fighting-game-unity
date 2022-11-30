using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static string siguienteNivel;

    public Animator animator;


    public void FadeOut(string sceneName)
    {
        animator.SetTrigger("FadeOut");
        StartCoroutine(WaitForChange(sceneName));
    }
    public static void ChangeScene(string sceneName)
    {
        siguienteNivel = sceneName;
        SceneManager.LoadScene("pantalla-carga");
    }
    IEnumerator WaitForChange(string sceneName)
    {
        yield return new WaitForSeconds(1.3f);
        ChangeScene(sceneName);
    }



}
