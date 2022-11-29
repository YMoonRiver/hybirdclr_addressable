using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wanderer.GameFramework
{
    public class LoadingEventArgs : GameEventArgs<LoadingEventArgs>
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string Tips;
        /// <summary>
        /// �������ؽ���
        /// </summary>
        public float Progress;
    }
}