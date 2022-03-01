using UnityEngine;

namespace Client
{
    public class flow_down : MonoBehaviour
    {
        private MeshRenderer _mr;
        private Material _mat;
        [SerializeField]
        private Vector2 _offset;

        public Camera camera;
        public float ParallaxRate;


        private void Start()
        {
            _mr = GetComponent<MeshRenderer>();
            _mat = _mr.material;
            _offset = _mat.mainTextureOffset;
        }

        private void FixedUpdate()
        {
            _offset += new Vector2(1f, 0);
        }
    }
}