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
    }
}

