using UnityEngine;
using UnityEngine.AI;
using System.Collections;   // 引用 系統 集合(資料結構) - 協同程序

namespace KID
{
    /// <summary>
    /// 受傷並且附帶掉落道具系統
    /// 繼承自受傷系統
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        #region 
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
        /// <summary>
        /// 等級管理器
        /// </summary>
        private LevelManager levelManager;

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

            levelManager = GameObject.Find("等級管理器").GetComponent<LevelManager>();
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
        #endregion

        protected override void Dead()
        {
            if (ani.GetBool(parameterDead)) return;

            base.Dead();

            nav.enabled = false;
            enemy.enabled = false;

            levelManager.ShowUI();

            StartCoroutine(DropCoin());
        }

        /// <summary>
        /// 掉落金幣
        /// </summary>
        private IEnumerator DropCoin()
        {
            float random = Random.value;                    // 取得隨機值 0 ~ 1

            if (random <= data.coinProbability)             // 判斷 隨機值 是否小於等於 機率
            {
                for (int i = 0; i < data.coinCount; i++)    // 迴圈重複生成道具
                {
                    Vector3 pos = new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1));

                    // 生成(物件，座標，角度)
                    GameObject temp = Instantiate(data.goCoin, transform.position + pos, Quaternion.Euler(90, Random.Range(0, 360), 0));
                    temp.GetComponent<Rigidbody>().AddForce(new Vector3(0, Random.Range(300, 500), 0));
                    yield return new WaitForSeconds(0.02f);
                }
            }
        }
    }
}

