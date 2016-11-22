using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickMenu : MonoBehaviour {

    [SerializeField] public RectTransform rect = null;
    [SerializeField] public GameObject[] quickMenu = null;
    [SerializeField] public float scaleSpd = 10f;
    [SerializeField] public float posSpd = 10f;


    void Awake () {
        _posX = GetComponent<RectTransform>();
	}
	

	void Update () {
        posX = rect.localPosition.x;
        _posX.localPosition = new Vector2( (posX / 7.2f) , -525);


        if ( posX > 360 && posX <= 1080 ) // quest
        {
            RectTransform _rect = quickMenu[0].GetComponent<RectTransform>();
            float scale = Mathf.Clamp((posX - 360f) / 720f, 0.6f, 1.0f);  
            float curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, (posX - 360f) / 24f);

            quickMenu[0].transform.localScale = Vector3.Lerp( quickMenu[0].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp( _rect.localPosition, targetPos, Time.deltaTime * posSpd);                                 // Position

            _rect = quickMenu[1].GetComponent<RectTransform>();
            scale = Mathf.Clamp(((posX * -1) + 1080f) / 720f, 0.6f, 1.0f);
            curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, ((posX * -1) + 1080f) / 24f);

            quickMenu[1].transform.localScale = Vector3.Lerp(quickMenu[1].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

        }
        else if (posX > -360 && posX <= 360)
        {
            RectTransform _rect = quickMenu[1].GetComponent<RectTransform>();
            float scale = Mathf.Clamp((posX + 360f) / 720f, 0.6f, 1.0f);
            float curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, (posX + 360f) / 24f);

            quickMenu[1].transform.localScale = Vector3.Lerp(quickMenu[1].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

            //

            _rect = quickMenu[2].GetComponent<RectTransform>();
            scale = Mathf.Clamp(((posX * -1f) + 360f) / 720f, 0.6f, 1.0f);
            curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, ((posX * -1f) + 360f) / 24f);

            quickMenu[2].transform.localScale = Vector3.Lerp(quickMenu[2].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

        }
        else if ( posX >= -1080 && posX <= -360 )
        {
            RectTransform _rect = quickMenu[2].GetComponent<RectTransform>();
            float scale = Mathf.Clamp(((posX) + 1080f) / 720f, 0.6f, 1.0f);
            float curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, (posX + 1080f) / 24f);

            quickMenu[2].transform.localScale = Vector3.Lerp(quickMenu[2].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

            //

            _rect = quickMenu[3].GetComponent<RectTransform>();
            scale = Mathf.Clamp(((posX * -1f) - 360f) / 720f, 0.6f, 1.0f);
            curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, ((posX * -1f) - 360f) / 24f);

            quickMenu[3].transform.localScale = Vector3.Lerp(quickMenu[3].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);
        }
    }

    private float posX;
    private RectTransform _posX;
    private Vector2 targetPos = Vector2.zero;
    private Vector3 targetScale = Vector3.zero;

}
