using UnityEngine;
using UnityEngine.UI;

namespace CnControls
{
    public class DpadAxis : MonoBehaviour
    {
        public string AxisName;
        public float AxisMultiplier;

        #region mycode
        public Sprite pointerDownImage;
        private Sprite defaultImage;
        private  Image image_;
        #endregion


        public RectTransform RectTransform { get; private set; }
        public int LastFingerId { get; set; }
        private VirtualAxis _virtualAxis;

        private void Awake()
        {
            image_ = this.GetComponent<Image> ();
            defaultImage = image_.sprite;

            RectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _virtualAxis = _virtualAxis ?? new VirtualAxis(AxisName);
            LastFingerId = -1;

            CnInputManager.RegisterVirtualAxis(_virtualAxis);
        }

        private void OnDisable()
        {
            CnInputManager.UnregisterVirtualAxis(_virtualAxis);
        }

        public void Press(Vector2 screenPoint, Camera eventCamera, int pointerId)
        {
            if (image_ != null) {
                image_.sprite = pointerDownImage;
            }

            _virtualAxis.Value = Mathf.Clamp(AxisMultiplier, -1f, 1f);
            LastFingerId = pointerId;
           // print ("pressed");
        }

        public void TryRelease(int pointerId)
        {
            image_.sprite = defaultImage;

          //  print ("released");
            if (LastFingerId == pointerId)
            {
                _virtualAxis.Value = 0f;
                LastFingerId = -1;
            }
        }
    }
}