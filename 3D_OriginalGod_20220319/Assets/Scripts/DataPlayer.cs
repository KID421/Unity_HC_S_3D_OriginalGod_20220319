using UnityEngine;

namespace KID
{
    /// <summary>
    /// ���a���
    /// ���šB�g��ȡB�����O
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Player", fileName = "Data player")]
    public class DataPlayer : ScriptableObject
    {
        [Header("����")]
        public int lv = 1;
        [Header("�g���")]
        public int exp;
        [Header("�����O")]
        public float attack = 20;
        [Header("��q")]
        public float hp = 1000;
        [Header("�ɵ������O")]
        public float lvUpAttack = 5;
        [Header("�ɵ���q")]
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

