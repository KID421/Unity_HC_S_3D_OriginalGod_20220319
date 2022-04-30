using UnityEngine;
using UnityEngine.AI;
using System.Collections;   // �ޥ� �t�� ���X(��Ƶ��c) - ��P�{��

namespace KID
{
    /// <summary>
    /// ���˨åB���a�����D��t��
    /// �~�Ӧۨ��˨t��
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
        #region 
        [SerializeField, Header("�ĤH���")]
        private DataEnemy data;
        [SerializeField, Header("�e���ĤH���")]
        private Transform traCanvasHp;

        /// <summary>
        /// ��v��
        /// </summary>
        private Transform traCamera;

        private NavMeshAgent nav;
        private Enemy enemy;
        /// <summary>
        /// ���ź޲z��
        /// </summary>
        private LevelManager levelManager;

        // override �Ƽg�����O�� virtual �����
        protected override void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
            enemy = GetComponent<Enemy>();

            // base.Awake();    // �����O�즳�����e
            hp = data.hp;
            hpMax = data.hp;
            UpdateHealthUI();
            traCamera = GameObject.Find("��v��").transform;

            levelManager = GameObject.Find("���ź޲z��").GetComponent<LevelManager>();
        }

        private void Update()
        {
            CanvasHpLookCamera();
        }

        /// <summary>
        /// �e����� ���V ��v��
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
        /// ��������
        /// </summary>
        private IEnumerator DropCoin()
        {
            float random = Random.value;                    // ���o�H���� 0 ~ 1

            if (random <= data.coinProbability)             // �P�_ �H���� �O�_�p�󵥩� ���v
            {
                for (int i = 0; i < data.coinCount; i++)    // �j�魫�ƥͦ��D��
                {
                    Vector3 pos = new Vector3(Random.Range(-1, 1), 1, Random.Range(-1, 1));

                    // �ͦ�(����A�y�СA����)
                    GameObject temp = Instantiate(data.goCoin, transform.position + pos, Quaternion.Euler(90, Random.Range(0, 360), 0));
                    temp.GetComponent<Rigidbody>().AddForce(new Vector3(0, Random.Range(300, 500), 0));
                    yield return new WaitForSeconds(0.02f);
                }
            }
        }
    }
}

