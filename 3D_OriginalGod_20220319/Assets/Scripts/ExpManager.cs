using UnityEngine;

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
        /// 顯示資訊管理器
        /// </summary>
        private ShowInfoManager showInfoManager;

        private void Awake()
        {
            showInfoManager = GameObject.Find("顯示資訊管理器").GetComponent<ShowInfoManager>();
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
            if (dataPlayer.exp >= dataExpTable.exps[dataPlayer.lv - 1])
            {
                dataPlayer.exp = 0;
                dataPlayer.lv++;
            }
        }
    }
}

