using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovementJoystick : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 inputDirection;

    public void OnDrag(PointerEventData eventData)
    {
        inputDirection = (eventData.position - (Vector2)transform.position).normalized;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
    }

    public Vector2 GetInputDirection()
    {
        return inputDirection;
    }
}