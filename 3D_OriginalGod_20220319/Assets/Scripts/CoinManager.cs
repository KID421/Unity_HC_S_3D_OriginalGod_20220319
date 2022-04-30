using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 金幣管理
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        /// <summary>
        /// 金幣文字
        /// </summary>
        [SerializeField, Header("金幣文字")]
        private Text textCoin;
        private int coinTotal;

        /// <summary>
        /// 添加金幣
        /// </summary>
        public void AddCoin()
        {
            coinTotal++;
            textCoin.text = "Coin " + coinTotal;
        }
    }
}
