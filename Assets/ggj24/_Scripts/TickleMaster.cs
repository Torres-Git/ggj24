using System.Collections;
using System.Collections.Generic;
using PowerTools;
using UnityEngine;
using DG.Tweening;

public class TickleMaster : MonoBehaviour
{
    [SerializeField] SpriteAnim _spriteAnim;
    [SerializeField] float _tickleRadius;
    [SerializeField] LayerMask _layerMask;
    private bool _isTickling = false;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0)) Tickle();
    }

    [ContextMenu("Tickle")]
    public void Tickle()
    {
        if(_isTickling) return;
        DOTween.Complete(transform);
        _isTickling = true;

        // Replace with your desired origin point (e.g., transform.position)
        Vector2 origin = transform.position;
        // Replace with your desired direction (e.g., transform.right)
        Vector2 direction = transform.right;

        // Perform the circle cast
        RaycastHit2D[] hits = Physics2D.CircleCastAll(origin, _tickleRadius, direction, Mathf.Infinity, _layerMask);

        // Process the hits
        foreach (RaycastHit2D hit in hits)
        {
            transform.DOPunchRotation(Vector3.forward * 45, .2f).OnComplete(()=>_isTickling = false);   
            // Do something with the hit information (e.g., print the name of the object)
            Debug.Log("Hit: " + hit.collider.gameObject.name);
        }
    }

#region Gizmos
    private void OnDrawGizmos()
    {
        DrawCircleCastGizmo();
    }
    private void OnDrawGizmosSelected()
    {
        DrawCircleCastGizmo();
    }
    private void DrawCircleCastGizmo()
    {
        // Gizmo color for the circle cast
        Gizmos.color = Color.yellow;

        // Draw the circle cast
        Gizmos.DrawWireSphere(transform.position, _tickleRadius);

        // Draw the direction of the circle cast
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(_tickleRadius * transform.right));
    }
#endregion
}
