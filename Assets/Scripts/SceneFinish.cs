using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFinish : MonoBehaviour
{
    public GameObject personajesFinish;
    public GameObject playerNiño;
    public GameObject CinematicaVirtual;
    public GameObject panelFinishMision2;
    public GameObject timerPanel;

    public GameObject panelHistory;
    public GameObject panelContinue;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNiño.SetActive(false);
            CinematicaVirtual.SetActive(true);
            StartCoroutine("DelayStartEnemy");
            panelFinishMision2.SetActive(false);
            timerPanel.SetActive(false);
            SubirAlpha(panelHistory, 1f, 2f, 3f);
            BajarAlpha(panelHistory, 0f, 2f, 6f);
            SubirAlpha(panelContinue, 1f, 3f, 10f);

        }

    }


    private void BajarAlpha(GameObject name, float state1, float animationTime, float StartAnimation)
    {
        LeanTween.alpha(name.GetComponent<RectTransform>(), state1, animationTime).setDelay(StartAnimation);


    }

    private void SubirAlpha(GameObject name, float stateF, float animationTim, float StrAnimation)
    {
        LeanTween.alpha(name.GetComponent<RectTransform>(), stateF, animationTim).setDelay(StrAnimation);
        //name.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }


    public IEnumerator DelayStartEnemy()
    {
        yield return new WaitForSeconds(8f);
        personajesFinish.SetActive(true);
    }
}
