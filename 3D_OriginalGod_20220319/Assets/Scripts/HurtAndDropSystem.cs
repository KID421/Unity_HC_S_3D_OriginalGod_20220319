using UnityEngine;
using UnityEngine.AI;

namespace KID
{
    /// <summary>
    /// 受傷並且附帶掉落道具系統
    /// 繼承自受傷系統
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;
        [SerializeField, Header("畫布敵人血條")]
        private Transform traCanvasHp;

        /// <summary>
        /// 攝影機
        /// </summary>
        private Transform traCamera;

        private NavMeshAgent nav;
        private Enemy enemy;

        // override 複寫父類別有 virtual 的資料
        protected override void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();

            // base.Awake();    // 父類別原有的內容
            hp = data.hp;
            hpMax = data.hp;
            UpdateHealthUI();
            traCamera = GameObject.Find("攝影機").transform;
        }

        private void Update()
        {
            CanvasHpLookCamera();
        }

        /// <summary>
        /// 畫布血條 面向 攝影機
        /// </summary>
        private void CanvasHpLookCamera()
        {
            traCanvasHp.eulerAngles = traCamera.eulerAngles;
        }

        protected override void Dead()
        {
            base.Dead();

            nav.enabled = false;
            enemy.enabled = false;
        }
    }
}

