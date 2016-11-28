using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickMenu : MonoBehaviour {

    [SerializeField] public RectTransform gridRect = null;
    [SerializeField] public GameObject[] quickMenu = null;
    [SerializeField] public float scaleSpd = 10f;
    [SerializeField] public float scaleRate = 10f;
    [SerializeField] public float posSpd = 10f;
    [SerializeField] public float posRate = 10f;


    void Awake () {
        _posX = GetComponent<RectTransform>();
	}
	

	void Update () {
        rectX = gridRect.localPosition.x;
        _posX.localPosition = new Vector2( (rectX / 7.2f) , -525);


        if ( rectX > 360 && rectX <= 1080 ) // quest
        {
            RectTransform _rect = quickMenu[0].GetComponent<RectTransform>();
            float scale = Mathf.Clamp((rectX - 360f) / 720f, 0.6f, 1.0f);  
            float curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, (rectX - 360f) / 24f);

            quickMenu[0].transform.localScale = Vector3.Lerp( quickMenu[0].transform.localScale, targetScale, Time.deltaTime * scaleSpd);
            _rect.localPosition = Vector2.Lerp( _rect.localPosition, targetPos, Time.deltaTime * posSpd);

            //

            _rect = quickMenu[1].GetComponent<RectTransform>();
            scale = Mathf.Clamp(((rectX * -1) + 1080f) / 720f, 0.6f, 1.0f);
            curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, ((rectX * -1) + 1080f) / 24f);

            quickMenu[1].transform.localScale = Vector3.Lerp(quickMenu[1].transform.localScale, targetScale, Time.deltaTime * scaleSpd);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

        }
        else if (rectX > -360 && rectX <= 360)
        {
            RectTransform _rect = quickMenu[1].GetComponent<RectTransform>();
            float scale = Mathf.Clamp((rectX + 360f) / 720f, 0.6f, 1.0f);
            float curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, (rectX + 360f) / 24f);

            quickMenu[1].transform.localScale = Vector3.Lerp(quickMenu[1].transform.localScale, targetScale, Time.deltaTime * scaleSpd);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

            //

            _rect = quickMenu[2].GetComponent<RectTransform>();
            scale = Mathf.Clamp(((rectX * -1f) + 360f) / 720f, 0.6f, 1.0f);
            curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, ((rectX * -1f) + 360f) / 24f);

            quickMenu[2].transform.localScale = Vector3.Lerp(quickMenu[2].transform.localScale, targetScale, Time.deltaTime * scaleSpd);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

        }
        else if ( rectX >= -1080 && rectX <= -360 )
        {
            RectTransform _rect = quickMenu[2].GetComponent<RectTransform>();
            float scale = Mathf.Clamp(((rectX) + 1080f) / 720f, 0.6f, 1.0f);
            float curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, (rectX + 1080f) / 24f);

            quickMenu[2].transform.localScale = Vector3.Lerp(quickMenu[2].transform.localScale, targetScale, Time.deltaTime * scaleSpd);
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);

            //

            _rect = quickMenu[3].GetComponent<RectTransform>();
            scale = Mathf.Clamp(((rectX * -1f) - 360f) / 720f, 0.6f, 1.0f);
            curPosX = _rect.localPosition.x;

            targetScale = new Vector3(scale, scale, 1);
            targetPos = new Vector2(curPosX, ((rectX * -1f) - 360f) / 24f);

            quickMenu[3].transform.localScale = Vector3.Lerp(quickMenu[3].transform.localScale, targetScale, Time.deltaTime * scaleSpd); // Scale
            _rect.localPosition = Vector2.Lerp(_rect.localPosition, targetPos, Time.deltaTime * posSpd);
        }
    }

    private float rectX;

    private RectTransform _posX;
    private Vector2 targetPos = Vector2.zero;
    private Vector3 targetScale = Vector3.zero;

}
