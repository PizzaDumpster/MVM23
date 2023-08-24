using UnityEngine;
using UnityEngine.UI;

public class ToggleTouchScreen : MonoBehaviour
{

    [SerializeField] Toggle myToggle;
    [SerializeField] Canvas mobileCanvas;

    // Start is called before the first frame update
    void Start()
    {
        myToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isMobilePlatform)
        {
            if (myToggle.isOn)
            {
                mobileCanvas.enabled = true;
            }
            else
            {
                mobileCanvas.enabled = false;
                Debug.Log("getting here");
            }
        }
    }
}
