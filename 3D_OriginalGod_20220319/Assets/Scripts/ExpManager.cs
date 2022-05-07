using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// �g��Ⱥ޲z
    /// �������a���g��ȡB�g��ȻݨD��B���Ÿ�ƨ�L���
    /// </summary>
    public class ExpManager : MonoBehaviour
    {
        [SerializeField, Header("���a���")]
        private DataPlayer dataPlayer;
        [SerializeField, Header("�g��ȻݨD����")]
        private DataExpTable dataExpTable;

        /// <summary>
        /// ����
        /// </summary>
        private Text textLv;
        /// <summary>
        /// ��q��r
        /// </summary>
        private Text textHp;

        /// <summary>
        /// ��ܸ�T�޲z��
        /// </summary>
        private ShowInfoManager showInfoManager;

        private void Awake()
        {
            showInfoManager = GameObject.Find("��ܸ�T�޲z��").GetComponent<ShowInfoManager>();
            textLv = GameObject.Find("����").GetComponent<Text>();
            textHp = GameObject.Find("��q��r").GetComponent<Text>();
            UpdatePlayerUI();
        }

        /// <summary>
        /// ���o�g���
        /// </summary>
        /// <param name="getExp">��o���g���</param>
        public void GetExp(int getExp)
        {
            dataPlayer.exp += getExp;

            showInfoManager.ShowUI("Exp", getExp);

            LevelUp();
        }

        /// <summary>
        /// ���Ŵ���
        /// </summary>
        private void LevelUp()
        {
            int expNeed = dataExpTable.exps[dataPlayer.lv - 1];

            while (dataPlayer.exp >= expNeed)
            {
                dataPlayer.exp -= expNeed;
                dataPlayer.lv++;
                expNeed = dataExpTable.exps[dataPlayer.lv - 1];
                dataPlayer.attack += dataPlayer.lvUpAttack;
                dataPlayer.hp += dataPlayer.lvUpHp;
                UpdatePlayerUI();
            }
        }

        /// <summary>
        /// ��s���a����
        /// </summary>
        private void UpdatePlayerUI()
        {
            textLv.text = "Lv" + dataPlayer.lv;
            textHp.text = dataPlayer.hp + " / " + dataPlayer.hp;
        }
    }
}

