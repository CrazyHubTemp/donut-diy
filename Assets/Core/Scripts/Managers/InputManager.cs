using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SwipeEvent : UnityEvent<SwipeData> { }
public class TouchEvent : UnityEvent<TouchData> { }

public enum SwipeDirection
{
    None,
    Up,
    Down,
    Right,
    Left
}
public class SwipeData
{
    public SwipeDirection direction;
    public float swipeVelocity;

    public SwipeData(SwipeDirection _direciton, float _velocity)
    {
        direction = _direciton;
        swipeVelocity = _velocity;
    }
}

public class TouchData
{
    public bool IsTouched = false;
}

public class InputManager : Singleton<InputManager>
{
    [HideInInspector]
    public SwipeEvent OnSwipe = new SwipeEvent();
    [HideInInspector]
    public TouchEvent OnTouch = new();

    [Header("Swipe Settings")]
    private float swipeHoldThreshold = 0.05f;
    private float swipeDistanceThreshold = 0.05f;

    Vector2 firstPos;
    Vector2 secondPos;
    float timePassed;

    private TouchData _touchData = new();

    private void Update()
    {
        if (EventSystem.current == null) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;
            if (EventSystem.current.IsPointerOverGameObject(id))
            {
                return;
            }
        }

        GetInputs();
    }

    private void GetInputs()
    {
        if (Input.touches.Any(x => x.phase == TouchPhase.Began))
        {
            //LevelManager.Instance.StartLevel();
            timePassed = 0;
            firstPos = Input.mousePosition;

            _touchData.IsTouched = true;
            OnTouch.Invoke(_touchData);
        }
        else if (Input.touches.Any(x => x.phase == TouchPhase.Ended))
        {
            secondPos = Input.mousePosition;

            _touchData.IsTouched = false;
            OnTouch.Invoke(_touchData);


            if (timePassed < swipeHoldThreshold || Vector2.Distance(firstPos, secondPos) < swipeDistanceThreshold)
                return;

            CalculateDirection();
        }

        if (Input.touches.Any())
        {
            timePassed += Time.deltaTime;
        }
    }

    private void CalculateDirection()
    {
        SwipeData swipeData = new SwipeData(SwipeDirection.None, 0);

        if (IsVerticalSwipe())
        {
            if (firstPos.y - secondPos.y < 0)
            {
                swipeData.direction = SwipeDirection.Up;
                swipeData.swipeVelocity = Vector2.Distance(firstPos.normalized, secondPos.normalized) * 1.5f;
                swipeData.swipeVelocity = Mathf.Clamp(swipeData.swipeVelocity, 0, 1f);
            }
            else if (firstPos.y - secondPos.y > 0)
            {
                swipeData.direction = SwipeDirection.Down;
                swipeData.swipeVelocity = 1;
            }
        }
        else
        {
            if (firstPos.x - secondPos.x < 0)
            {
                swipeData.direction = SwipeDirection.Right;
                swipeData.swipeVelocity = 1;
            }
            else if (firstPos.x - secondPos.x > 0)
            {
                swipeData.direction = SwipeDirection.Left;
                swipeData.swipeVelocity = 1;
            }
        }

        OnSwipe.Invoke(swipeData);
    }

    private bool IsVerticalSwipe()
    {
        if (VerticalDistance() > HorizontalDistance())
            return true;
        else
            return false;
    }

    private float VerticalDistance()
    {
        return Mathf.Abs(firstPos.y - secondPos.y);
    }

    private float HorizontalDistance()
    {
        return Mathf.Abs(firstPos.x - secondPos.x);
    }
}
