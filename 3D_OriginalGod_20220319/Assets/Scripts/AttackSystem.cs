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
        [SerializeField, Header("第一階段收刀時間")]
        private float timeSwordToBack = 2.5f;
        [SerializeField, Header("第二階段收刀時間")]
        private float timeSwordToHide = 3.5f;

        private string parameterAttack = "觸發攻擊";
        private bool isAttack;
        private bool isBack;
        private float timer;
        private float timerToHide;
        #endregion

        #region 事件
        private void Awake()
        {
            ani = GetComponent<Animator>();
        }

        private void Update()
        {
            SwitchWeapon();
            SwordToBack();
            SwordToHide();
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

                timer = 0;                          // 每次攻擊計時器重算
                isAttack = true;
            }
        }

        /// <summary>
        /// 收刀第一階段：刀子從手上收回背後
        /// </summary>
        private void SwordToBack()
        {
            if (isAttack)
            {
                timer += Time.deltaTime;

                if (timer >= timeSwordToBack)
                {
                    goWeaponHand.SetActive(false);
                    goWeaponBack.SetActive(true);

                    timer = 0;                      // 收刀後計時器歸零
                    timerToHide = 0;
                    isAttack = false;
                    isBack = true;
                }
            }
        }

        /// <summary>
        /// 收刀第二階段：從背後隱藏
        /// </summary>
        private void SwordToHide()
        {
            if (isBack)
            {
                timerToHide += Time.deltaTime;

                if (timerToHide >= timeSwordToHide)
                {
                    goWeaponBack.SetActive(false);

                    timerToHide = 0;
                    isBack = false;
                }
            }
        }
        #endregion
    }
}

