using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人資料
    /// 1. 血量
    /// 2. 攻擊
    /// 3. 移動速度
    /// 4. 追蹤範圍
    /// 5. 攻擊範圍
    /// 6. 經驗值
    /// 7. 金幣物件
    /// 8. 掉金幣數量
    /// 9. 掉金幣機率
    /// </summary>
    // Create Asset Menu 建立資料選項
    // menuName 選項名稱，可以使用 / 建立子選項（建議英文）
    // fileName 檔案名稱（建議英文）
    [CreateAssetMenu(menuName = "KID/Data Enemy", fileName = "Data Enemy")]
    // Scriptable Object 腳本化物件：將資料以物件方式儲存於 Project 內
    public class DataEnemy : ScriptableObject
    {
        [Header("血量"), Range(0, 1000)]
        public float hp;
        [Header("攻擊"), Range(0, 100)]
        public float attack;
        [Header("攻擊冷卻"), Range(0, 5)]
        public float cd;
        [Header("延遲傳送傷害"), Range(0, 2)]
        public float delaySendDamage;
        [Header("移動速度"), Range(0, 50)]
        public float speed;
        [Header("追蹤範圍"), Range(7, 50)]
        public float rangeTrack;
        [Header("攻擊範圍"), Range(0, 7)]
        public float rangeAttack;
        [Header("攻擊區域位移")]
        public Vector3 v3AttackOffset;
        [Header("攻擊區域尺寸")]
        public Vector3 v3AttackSize = Vector3.one;
        [Header("經驗值"), Range(0, 1000)]
        public float exp;
        [Header("金幣物件")]
        public GameObject goCoin;
        [Header("金幣數量"), Range(0, 500)]
        public int coinCount;
        [Header("金幣掉落機率"), Range(0, 1)]
        public float coinProbability;
    }
}

