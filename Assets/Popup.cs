using System.Collections;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{

    public static Popup instance;

    [SerializeField] CanvasGroup myCanvas;
    [SerializeField] TMP_Text myText;
    [SerializeField] bool isFadingIn = false;
    [SerializeField] bool isFadingOut = false;
    [SerializeField] bool isFading = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        myCanvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayPopup(string inject)
    {
        StartCoroutine(ShowCanvas(inject));
    }

    public IEnumerator ShowCanvas(string msgText)
    {

        myText.text = msgText;
        if (!isFading)
        {
            if (!isFadingIn)
                StartCoroutine(FadeCanvasIn());
            yield return new WaitForSeconds(2f);
            if (!isFadingOut)
                StartCoroutine(FadeCanvasOut());
        }

        yield return null;
    }

    IEnumerator FadeCanvasIn()
    {
        isFading = true;
        isFadingIn = true;
        myCanvas.alpha = 0;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.1f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.2f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.3f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.4f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.5f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.6f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.7f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.8f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.9f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 1f;
        isFadingIn = false;
    }
    IEnumerator FadeCanvasOut()
    {
        isFadingOut = true;
        myCanvas.alpha = 1f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.9f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.8f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.7f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.6f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.5f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.4f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.3f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.2f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0.1f;
        yield return new WaitForSeconds(0.1f);
        myCanvas.alpha = 0f;
        isFadingOut = false;
        isFading = false;
    }

}
