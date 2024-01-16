using UnityEngine;

namespace Script.Manager.Contents
{
    public class Note : MonoBehaviour
    {
        [SerializeField] private GameObject _content;
        public Transform GetContentTransform => _content.transform;
    }
}