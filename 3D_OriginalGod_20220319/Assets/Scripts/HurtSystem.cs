using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 受傷系統
    /// </summary>
    public class HurtSystem : MonoBehaviour
    {
        [SerializeField, Header("血量"), Range(0, 5000)]
        private float hp = 100;
        [Header("血條介面")]
        [SerializeField]
        private Text textHp;
        [SerializeField]
        private Image imgHp;

        private float hpMax;

        private void Awake()
        {
            hpMax = hp;
            UpdateHealthUI();
        }

        /// <summary>
        /// 更新血量介面
        /// </summary>
        private void UpdateHealthUI()
        {
            textHp.text = hp + " / " + hpMax;
            imgHp.fillAmount = hp / hpMax;
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害</param>
        public void GetHurt(float damage)
        {
            hp -= damage;
            UpdateHealthUI();
        }
    }
}
