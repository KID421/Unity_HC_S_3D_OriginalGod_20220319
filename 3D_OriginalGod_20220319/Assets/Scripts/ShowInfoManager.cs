using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 顯示資訊管理器
    /// </summary>
    public class ShowInfoManager : MonoBehaviour
    {
        [SerializeField, Header("獲得物品資訊介面")]
        private CanvasGroup groupInfo;
        [SerializeField, Header("提示訊息")]
        private Text textInfo;

        public void ShowUI(string info, int value)
        {
            print("顯示物品資訊：" + info + "\n數值：" + value);

            StartCoroutine(FadeIn());
            StartCoroutine(ScaleToOne());

            textInfo.text = info + " + " + value;
        }

        private IEnumerator FadeIn()
        {
            yield return new WaitForSeconds(0.2f);

            for (int i = 0; i < 10; i++)
            {
                groupInfo.alpha += 0.1f;
                yield return new WaitForSeconds(0.05f);
            }
        }

        private IEnumerator ScaleToOne()
        {
            yield return new WaitForSeconds(0.2f);
            RectTransform rect = groupInfo.GetComponent<RectTransform>();

            for (int i = 0; i < 10; i++)
            {
                rect.localScale += new Vector3(0, 0.1f, 0);
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
