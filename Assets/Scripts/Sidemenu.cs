using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sidemenu : MonoBehaviour {

    [SerializeField] public GridLayoutGroup _grid = null;
    [SerializeField] public RectTransform[] _panels = null;
    [SerializeField] public RectTransform _UI = null;
    [SerializeField] public GameObject _blind = null;

    void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if ( _on)
        {
            
            SidemenuSum();
        }

    }

    public void CallSidemenu()
    {
        if ( !_on)
        {
            
            StopCoroutine("RemoveBlind");
            StartCoroutine("CallBlind");
            
            _on = true;
        }

    }

    public void CallSetting() {
        if (!_on) {
            StopCoroutine("RemoveBlind");
            StartCoroutine("CallBlind");
            
            _on = true;
        }
    }

    public void Cancel() {
        if (_on) {
            StopCoroutine("CallBlind");
            StartCoroutine("RemoveBlind");
            
            _on = false;
        }
    }

    void SidemenuSum() {
        Vector2 target1 = new Vector2(-1080f, 0f);

        _panels[0].localPosition = Vector2.Lerp(_panels[0].localPosition, target1, Time.deltaTime * 10.0f);

        Vector2 target2 = new Vector2(360f, 0);
        _rect.localPosition = Vector2.Lerp(_rect.localPosition, target2, Time.deltaTime * 10.0f);
        _UI.localPosition = Vector2.Lerp(_UI.localPosition, target2, Time.deltaTime * 10.0f);

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

    private RectTransform _rect;
    private GameObject _gridObj;

    private float alpha = 0f;
    private bool _on = false;
}
