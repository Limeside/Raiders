using UnityEngine;
using System.Collections;

public class ScrollRectTest : MonoBehaviour {

    [SerializeField] GameObject[] panels = null;

	void Start () {
	
	}
	
	void Update () {
	    if ( _onMouse)
        {
            Debug.Log("Hello");
        }
	}

    void OnMouseDown ()
    {
        if ( !_onMouse)
        {
            _onMouse = true;
        }
    }

    void OnMouseUp()
    {
        if (_onMouse)
        {
            _onMouse = false;
        }
    }

    

    private bool _onMouse = false;
}
