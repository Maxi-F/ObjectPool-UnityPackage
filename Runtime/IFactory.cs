using UnityEngine;

namespace Runtime
{
    public interface IFactory<in TConfig>
    {
        public void SetConfig(TConfig config);
        public GameObject CreateObject();
    }
}
