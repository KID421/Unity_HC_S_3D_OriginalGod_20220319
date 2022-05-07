using UnityEngine;

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
        /// ��ܸ�T�޲z��
        /// </summary>
        private ShowInfoManager showInfoManager;

        private void Awake()
        {
            showInfoManager = GameObject.Find("��ܸ�T�޲z��").GetComponent<ShowInfoManager>();
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
            if (dataPlayer.exp >= dataExpTable.exps[dataPlayer.lv - 1])
            {
                dataPlayer.exp = 0;
                dataPlayer.lv++;
            }
        }
    }
}

