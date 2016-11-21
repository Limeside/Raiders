using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickMenu : MonoBehaviour {

    [SerializeField] public RectTransform _rect = null;
    [SerializeField] public GameObject[] quickMenu = null;

    void Awake () {
        posX = _rect.localPosition.x;
	}
	

	void Update () {
        Debug.Log(posX);

        transform.localPosition = new Vector2( (posX / 7.2f) , -525);

        /*
        if ( posX )
        {

        }
        */
	}

    private float posX;
}
