using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家資料
    /// 等級、經驗值、攻擊力
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Player", fileName = "Data player")]
    public class DataPlayer : ScriptableObject
    {
        [Header("等級")]
        public int lv = 1;
        [Header("經驗值")]
        public int exp;
        [Header("攻擊力")]
        public float attack = 20;
        [Header("血量")]
        public float hp = 1000;
        [Header("升等攻擊力")]
        public float lvUpAttack = 5;
        [Header("升等血量")]
        public float lvUpHp = 100;

        [ContextMenu("Reset To Original")]
        private void RestToOriginal()
        {
            lv = 1;
            exp = 0;
            attack = 20;
            hp = 1000;
        }
    }
}

