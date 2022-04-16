using UnityEngine;

/// <summary>
/// KID 命名空間
/// </summary>
namespace KID
{
    /// <summary>
    /// 攻擊系統
    /// 1. 武器切換
    /// 2. 攻擊動畫
    /// 3. 刀光特效
    /// 4. 攻擊判定
    /// </summary>
    public class AttackSystem : MonoBehaviour
    {
        #region 欄位
        private Animator ani;

        // SerializeField 序列化欄位：將私人欄位顯示於屬性面板

        [SerializeField, Header("武器 背後")]
        private GameObject goWeaponBack;
        [SerializeField, Header("武器 手上")]
        private GameObject goWeaponHand;
        [SerializeField, Header("刀光")]
        private ParticleSystem psLight;

        private string parameterAttack = "觸發攻擊";
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            SwitchWeapon();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 切換武器
        /// </summary>
        private void SwitchWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                goWeaponHand.SetActive(true);
                goWeaponBack.SetActive(false);

                ani.SetTrigger(parameterAttack);    // 觸發攻擊動畫
                psLight.Play();                     // 播放攻擊特效
            }
        }
        #endregion
    }
}

