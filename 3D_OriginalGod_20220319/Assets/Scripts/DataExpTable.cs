using UnityEngine;

namespace KID
{
    /// <summary>
    /// 經驗值需求表資料
    /// 1 ~ 99 經驗值需求
    /// 等級 1：100
    /// 等級 2：200
    /// 等級 99：9900
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Exp Table", fileName = "Data Exp Table")]
    public class DataExpTable : ScriptableObject
    {
        [Header("等級 1 ~ 99 經驗值需求")]
        public int[] exps;

        /// <summary>
        /// 建立經驗值需求表資料
        /// </summary>
        // ContextMenu 選單內容，在屬性面板 點點點 設定按鈕 可以選取執行此方法
        [ContextMenu("Create Exp Data")]
        private void CreateExpData()
        {
            exps = new int[99];

            for (int i = 0; i < exps.Length; i++)
            {
                exps[i] = (i + 1) * 100;
            }
        }
    }
}

