using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// ���ź޲z��
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        [SerializeField, Header("��o���~��T����")]
        private CanvasGroup groupInfo;
        [SerializeField, Header("���ܰT��")]
        private Text textInfo;

        public void ShowUI()
        {
            print("��ܪ��~��T");
        }
    }
}
