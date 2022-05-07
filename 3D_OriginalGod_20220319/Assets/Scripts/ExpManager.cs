using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 經驗值管理
    /// 紀錄玩家的經驗值、經驗值需求表、等級資料其他資料
    /// </summary>
    public class ExpManager : MonoBehaviour
    {
        [SerializeField, Header("玩家資料")]
        private DataPlayer dataPlayer;
        [SerializeField, Header("經驗值需求表資料")]
        private DataExpTable dataExpTable;

        /// <summary>
        /// 等級
        /// </summary>
        private Text textLv;
        /// <summary>
        /// 血量文字
        /// </summary>
        private Text textHp;

        /// <summary>
        /// 顯示資訊管理器
        /// </summary>
        private ShowInfoManager showInfoManager;

        private void Awake()
        {
            showInfoManager = GameObject.Find("顯示資訊管理器").GetComponent<ShowInfoManager>();
            textLv = GameObject.Find("等級").GetComponent<Text>();
            textHp = GameObject.Find("血量文字").GetComponent<Text>();
            UpdatePlayerUI();
        }

        /// <summary>
        /// 取得經驗值
        /// </summary>
        /// <param name="getExp">獲得的經驗值</param>
        public void GetExp(int getExp)
        {
            dataPlayer.exp += getExp;

            showInfoManager.ShowUI("Exp", getExp);

            LevelUp();
        }

        /// <summary>
        /// 等級提升
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
        /// 更新玩家介面
        /// </summary>
        private void UpdatePlayerUI()
        {
            textLv.text = "Lv" + dataPlayer.lv;
            textHp.text = dataPlayer.hp + " / " + dataPlayer.hp;
        }
    }
}

