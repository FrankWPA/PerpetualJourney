using System;
using UnityEngine;

namespace PerpetualJourney
{
    public class Collectable : LaneObject
    {
        [SerializeField]private LeanTweenType _lean_type = LeanTweenType.easeInOutQuad;
        [SerializeField]private float RotateTweenAngles = 360;
        [SerializeField]private float RotateTweenTime = 2;
        [SerializeField]private float LocalYTween = 0.5f;
        [SerializeField]private float LocalYTweenTime = 1;

        private event Action _levelPartDisable;

        public void Initialize(int lane, Action levelPartDisable)
        {
            _levelPartDisable = levelPartDisable;
            _levelPartDisable += this.RetrieveToObjectPool;

            Initialize(lane);
        }

        public override void Initialize(int lane)
        {
            base.Initialize(lane);

            LTDescr rotateTween = LeanTween.rotateAround(gameObject, Vector3.up, RotateTweenAngles, RotateTweenTime);
            rotateTween.setRepeat(-1);

            LTDescr moveLocalYTween = LeanTween.moveLocalY(gameObject, transform.position.y + LocalYTween, LocalYTweenTime);
            moveLocalYTween.setLoopPingPong();
            moveLocalYTween.setRepeat(-1);
            moveLocalYTween.setEase(_lean_type);
        }

        private void OnDisable()
        {
            ResetTweenAndPosition();
        }

        private void ResetTweenAndPosition()
        {
            transform.LeanSetLocalPosY(0);
            LeanTween.cancel(gameObject);
        }

        protected override void CollidedWithPlayer()
        {
            GameEvent.CollectableCollision();
            _levelPartDisable -= this.RetrieveToObjectPool;
            this.RetrieveToObjectPool();
        }
    }
}
