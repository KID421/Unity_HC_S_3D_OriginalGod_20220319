using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 等級管理器
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [SerializeField, Header("獲得物品資訊介面")]
        private CanvasGroup groupInfo;
        [SerializeField, Header("提示訊息")]
        private Text textInfo;

        public void ShowUI()
        {
            print("顯示物品資訊");
        }
    }
}
