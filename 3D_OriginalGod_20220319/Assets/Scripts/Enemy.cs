using UnityEngine;
using UnityEngine.AI;

namespace KID
{
    /// <summary>
    /// 敵人：基本行為
    /// 追蹤、攻擊、受傷與死亡
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        [SerializeField, Header("怪物資料")]
        private DataEnemy data;
        [SerializeField, Header("玩家物件名稱")]
        private string namePlayer = "學生妹";
        [SerializeField, Header("追蹤目標圖層")]
        private LayerMask layerTrack;

        private Animator ani;
        private NavMeshAgent nav;
        private Transform traPlayer;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeAttack);
        }

        private void Update()
        {
            CheckPlayerInTrackRange();
        }

        /// <summary>
        /// 檢查玩家是否在追蹤範圍內
        /// </summary>
        private void CheckPlayerInTrackRange()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, data.rangeTrack, layerTrack);
            print(hits[0].name);
        }
    }
}

