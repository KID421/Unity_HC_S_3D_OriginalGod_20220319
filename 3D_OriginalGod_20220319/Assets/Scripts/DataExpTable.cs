using UnityEngine;

namespace KID
{
    /// <summary>
    /// �g��ȻݨD����
    /// 1 ~ 99 �g��ȻݨD
    /// ���� 1�G100
    /// ���� 2�G200
    /// ���� 99�G9900
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Exp Table", fileName = "Data Exp Table")]
    public class DataExpTable : ScriptableObject
    {
        [Header("���� 1 ~ 99 �g��ȻݨD")]
        public int[] exps;

        /// <summary>
        /// �إ߸g��ȻݨD����
        /// </summary>
        // ContextMenu ��椺�e�A�b�ݩʭ��O �I�I�I �]�w���s �i�H������榹��k
        [ContextMenu("Create Exp Data")]
        private void CreateExpData()
        {
            exps = new int[99];

            for (int i = 0; i < exps.Length; i++)
            {
                exps[i] = (i + 1) * 100;
            }
        }
    }
}

