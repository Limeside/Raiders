using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sidemenu : MonoBehaviour {

    [SerializeField] public GridLayoutGroup _grid = null;
    [SerializeField] public RectTransform _panel = null;
    [SerializeField] public GameObject _blind = null;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    public void SidemenuButton() {
        if ( !_on) {
            StopCoroutine("RemoveBlind");
            StartCoroutine("CallBlind");

            StartCoroutine("CallSidemenu");
            StopCoroutine("Close");

            _on = true;
        }
    }

    public void SettingButton() {
        if (!_on) {
            StopCoroutine("RemoveBlind");
            StartCoroutine("CallBlind");

            StartCoroutine("CallSetting");
            StopCoroutine("Close");

            _on = true;
        }
    }

    public void Cancel() {
        if (_on) {
            StopCoroutine("CallBlind");
            StartCoroutine("RemoveBlind");

            StopCoroutine("CallSidemenu");
            StopCoroutine("CallSetting");
            StartCoroutine("Close");

            _on = false;
        }
    }

    IEnumerator CallBlind() {
        _blind.SetActive(true);

        while ( alpha < 0.5f ) {
            alpha += 2.2f * Time.deltaTime;
            _blind.GetComponent<Image>().color = new Color(0,0,0, alpha);

            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator RemoveBlind() {
        while (alpha > 0f) {
            alpha -= 2.2f * Time.deltaTime;
            _blind.GetComponent<Image>().color = new Color(0, 0, 0, alpha);

            yield return new WaitForEndOfFrame();
        }

        _blind.SetActive(false);
    }

    IEnumerator CallSidemenu() {
        Vector2 target = new Vector2(360f, 0f);

        while (Mathf.RoundToInt(_rect.localPosition.x) != 360f)
        {
            Debug.Log("Sidemenu");
            _panel.localPosition = Vector2.Lerp(_panel.localPosition, target, Time.deltaTime * 10.0f);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, target, Time.deltaTime * 10.0f);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator CallSetting() {
        Vector2 target = new Vector2(-360f, 0f);

        while (Mathf.RoundToInt(_rect.localPosition.x) != -360f)
        {
            Debug.Log("Setting");
            _panel.localPosition = Vector2.Lerp(_panel.localPosition, target, Time.deltaTime * 10.0f);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, target, Time.deltaTime * 10.0f);
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator Close() {
        Vector2 target = new Vector2(0f, 0f);

        while (Mathf.RoundToInt(_rect.localPosition.x) != 0f)
        {
            Debug.Log("Close");
            _panel.localPosition = Vector2.Lerp(_panel.localPosition, target, Time.deltaTime * 10.0f);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, target, Time.deltaTime * 10.0f);
            yield return new WaitForEndOfFrame();
        }
    }

    private RectTransform _rect;
    private GameObject _gridObj;

    private float alpha = 0f;
    private bool _on = false;
}
