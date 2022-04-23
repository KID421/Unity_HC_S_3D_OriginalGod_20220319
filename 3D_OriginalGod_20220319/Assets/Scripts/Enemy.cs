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
        private float timerAttack;
        private string parameterWalk = "開關走路";
        private string parameterAttack = "觸發攻擊";
        private HurtSystem hurtPlayer;

        private void Awake()
        {
            ani = GetComponent<Animator>();
            nav = GetComponent<NavMeshAgent>();

            traPlayer = GameObject.Find(namePlayer).transform;
            hurtPlayer = traPlayer.GetComponent<HurtSystem>();

            nav.speed = data.speed;
            nav.stoppingDistance = data.rangeAttack;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 0, 1, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeTrack);

            Gizmos.color = new Color(1, 0, 0, 0.35f);
            Gizmos.DrawSphere(transform.position, data.rangeAttack);

            Gizmos.color = new Color(1, 0.7f, 0, 0.6f);
            Gizmos.matrix = Matrix4x4.TRS(
                transform.position + transform.TransformDirection(data.v3AttackOffset),
                transform.rotation, transform.localScale);
            Gizmos.DrawCube(Vector3.zero, data.v3AttackSize);
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

            if (hits.Length > 0)
            {
                MoveToPlayer();
            }
            else
            {
                nav.isStopped = true;               // 停止 導覽代理器
                ani.SetBool(parameterWalk, false);  // 等待
            }
        }

        /// <summary>
        /// 移動至玩家位置
        /// </summary>
        private void MoveToPlayer()
        {
            nav.isStopped = false;                      // 恢復 導覽代理器
            nav.SetDestination(traPlayer.position);

            // print("距離：" + nav.remainingDistance);

            if (nav.remainingDistance < data.rangeAttack)       // 如果 剩餘距離 < 攻擊範圍 就進行攻擊
            {
                if (timerAttack >= data.cd)
                {
                    timerAttack = 0;
                    ani.SetTrigger(parameterAttack);            // 冷卻後攻擊
                    CheckAttackArea();
                }
                else
                {
                    timerAttack += Time.deltaTime;
                    ani.SetBool(parameterWalk, false);          // 冷卻間隔，不走路
                }
            }
            else 
            {
                ani.SetBool(parameterWalk, true);               // 剩餘距離 > 攻擊範圍 進行走路動作
            }
        }

        /// <summary>
        /// 檢查攻擊區域
        /// </summary>
        private void CheckAttackArea()
        {
            transform.LookAt(traPlayer);            // 面向玩家

            // Physics.OverlapBox 矩形覆蓋碰撞
            // (中心點，一半尺寸，角度，圖層)
            // Quaternion.identity 零度角
            Collider[] hits = Physics.OverlapBox(
                transform.position + transform.TransformDirection(data.v3AttackOffset),
                data.v3AttackSize / 2, Quaternion.identity, layerTrack);

            if (hits.Length > 0)
            {
                // print("<color=yellow>敵人擊中的目標：" + hits[0].name + "</color>");
                hurtPlayer.GetHurt(data.attack);        // 傳遞攻擊力給玩家的受傷系統
            }
        }
    }
}

