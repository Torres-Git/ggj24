using System.Collections;
using System.Collections.Generic;
using PowerTools;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class TickleMaster : MonoBehaviour
{
    [SerializeField] bool _isTickleAll = false;
    [SerializeField] SpriteAnim _spriteAnim;
    [SerializeField] float _tickleRadius;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] private bool _isTickling = false;
    [SerializeField] private Vector2 _castOffset;
    private Tween _animTween = null;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0)) Tickle();
    }

    [ContextMenu("Tickle")]
    public void Tickle()
    {
        // if(_isTickling) return;
        DOTween.Complete(_animTween);
        
        // Replace with your desired origin point (e.g., transform.position)
        Vector2 origin = transform.position;
        // Replace with your desired direction (e.g., transform.right)
        Vector2 direction = transform.forward;

        // Perform the circle cast
        RaycastHit2D[] hits = Physics2D.CircleCastAll(origin + _castOffset, _tickleRadius, direction, Mathf.Infinity, _layerMask);

        if(hits.Length>0)
            if(_isTickleAll)
            {
                foreach(var hit in hits)
                {
                    var enemy = hit.collider.GetComponent<IEnemy>();
                    if(enemy!= null)
                    {
                        enemy.Tickle();
                    }

                    _isTickling = true;
                    _animTween = transform.DOPunchRotation(Vector3.forward * 45, .2f).OnComplete(()=>_isTickling = false).SetAutoKill(true);   
                }
            }
            else
            {                
                var enemy = hits[0].collider.GetComponent<IEnemy>();
                if(enemy!= null)
                {
                    enemy.Tickle();
                }

                _isTickling = true;
                _animTween = transform.DOPunchRotation(Vector3.forward * 45, .2f).OnComplete(()=>_isTickling = false).SetAutoKill(true);   
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
        Gizmos.DrawWireSphere(transform.position+ (Vector3)_castOffset, _tickleRadius);

        Gizmos.color = Color.red;

        // Draw the direction of the circle cast
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)(_tickleRadius * transform.forward));
    }
#endregion
}
