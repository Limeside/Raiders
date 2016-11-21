using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 1. 이동 방향
 2. 도착 위치
 3. 이동 후 정지
*/

public class ScrollViewSnap : MonoBehaviour
{

    ScrollRect _scrollRect = null;
    RectTransform _rect = null;
    GridLayoutGroup _grid = null;

    void Start() {
        _scrollRect = GetComponentInParent<ScrollRect>();
        _rect = GetComponent<RectTransform>();
        _grid = GetComponent<GridLayoutGroup>();
    }

    void Update() {
        _scrollRect.velocity = new Vector2(Input.GetAxisRaw("Mouse X") * GetMouseDelta(), 0);

        if (!isMove) {
            if (Mathf.Abs(_scrollRect.velocity.x) > 30) // 움직임 체크
            {
                dir = Mathf.Sign(_scrollRect.velocity.x); // 1차원 방향 -1 , 1, 0
                target.x = (dir * _grid.cellSize.x) + currentPos; // grid.cellSize.x => width

                target.x = Mathf.Clamp(target.x, -1080, 1080); // 이동 최대치
                isMove = true;
            }
        }

        if (!isMove)
            return;

        _rect.localPosition = Vector2.Lerp(_rect.localPosition, target, Time.deltaTime * 10); // 이동

        if (Vector3.Distance(_rect.localPosition, target) < 5) // 거리가 5보다 작다면 정지
        {
            isMove = false;

            _rect.localPosition = target;
            currentPos = target.x;
            dir = 0;
        }

        // Debug.Log("velocity " + _scrollRect.velocity);
    }

    private float GetMouseDelta()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = Vector2.zero;
        }

        if (Input.GetMouseButton(0))
        {
            return Mathf.Abs(Input.mousePosition.x - mouseDown.x);
        }

        return 0;
    }

    private Vector2 target = Vector2.zero;
    private Vector2 mouseDown = Vector2.zero;

    private bool isMove = false;
    private float currentPos = 0;
    private float dir = 0;

}
