using UnityEngine;
using UnityEngine.AI;

namespace KID
{
    /// <summary>
    /// ���˨åB���a�����D��t��
    /// �~�Ӧۨ��˨t��
    /// </summary>
    public class HurtAndDropSystem : HurtSystem
    {
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

        protected override void Dead()
        {
            base.Dead();

            nav.enabled = false;
            enemy.enabled = false;
        }
    }
}

