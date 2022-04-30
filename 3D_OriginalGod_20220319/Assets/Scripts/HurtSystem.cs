using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// ���˨t��
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("��q"), Range(0, 5000)]
        protected float hp = 100;
        [Header("�������")]
        [SerializeField]
        private Text textHp;
        [SerializeField]
        private Image imgHp;
        [SerializeField, Header("���`�ʵe�Ѽ�")]
        private string parameterDead = "�}�����`";

        private Animator ani;

        protected float hpMax;

        // protected �O�@�׹����G�P�p�H�ܬۦ��A�Ȥ��\�l���O�s���O�@�ŧO���
        // virtual �����G���\�l���O�Ƽg
        protected virtual void Awake()
        {
            hpMax = hp;
            UpdateHealthUI();
        }

        private void Start()
        {
            ani = GetComponent<Animator>();
        }

        /// <summary>
        /// ��s��q����
        /// </summary>
        protected void UpdateHealthUI()
        {
            textHp.text = hp + " / " + hpMax;
            imgHp.fillAmount = hp / hpMax;
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="damage">���쪺�ˮ`</param>
        public void GetHurt(float damage)
        {
            hp -= damage;
            UpdateHealthUI();

            if (hp <= 0) Dead();
        }

        /// <summary>
        /// ���`
        /// </summary>
        protected virtual void Dead()
        {
            hp = 0;
            ani.SetBool(parameterDead, true);
        }
    }
}
