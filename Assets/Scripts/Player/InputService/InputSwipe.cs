using UnityEngine;
using System;

public class InputSwipe : MonoBehaviour
{
    [SerializeField] private int _minDragingRange = 125;
    [SerializeField] private int _maxDragingRange = 500;

    private Vector2 _startTouch;
    private Vector2 _swipeDelta;

    public Action OnSwipeLeft;
    public Action OnSwipeRight;

    private void Update()
    {
        Inputs();
    }

    private void Inputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _swipeDelta = Vector2.zero;
            _swipeDelta = (Vector2)Input.mousePosition - _startTouch;

            Swipe();

            _startTouch = Vector2.zero;
            _swipeDelta = Vector2.zero;
        }
    }

    private void Swipe()
    {
        if(_swipeDelta.magnitude > _minDragingRange && _swipeDelta.magnitude < _maxDragingRange)
        {
            float x = _swipeDelta.x;
            if (x < 0)
                OnSwipeLeft?.Invoke();
            else
                OnSwipeRight?.Invoke();
        }
    }
}
