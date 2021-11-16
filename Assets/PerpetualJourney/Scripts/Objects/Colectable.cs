using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Colectable : LaneObject
    {
        [SerializeField]private LeanTweenType _lean_type;

        private const float RotateAnimAngles = 360;
        private const float RotateAnimTime = 2;
        private const float LocalYAnimDelta = 0.5f;
        private const float LocalYAnimTime = 1;

        public override void Initialize(int lane)
        {
            base.Initialize(lane);

            LTDescr rotateTween = LeanTween.rotateAround(gameObject, Vector3.up, RotateAnimAngles, RotateAnimTime);
            rotateTween.setRepeat(-1);

            LTDescr moveLocalYTween = LeanTween.moveLocalY(gameObject, transform.position.y + LocalYAnimDelta, LocalYAnimTime);
            moveLocalYTween.setLoopPingPong();
            moveLocalYTween.setRepeat(-1);
            moveLocalYTween.setEase(_lean_type);
        }

        private void OnDisable() 
        {
            LeanTween.cancel(gameObject);
        }

        protected override void CollidedWithPlayer()
        {
            GameEvent.ColectableCollision();
        }
    }
}
