using System;
using UnityEngine;

namespace PerpetualJourney
{
    public class Collectable : LaneObject
    {
        [SerializeField] private LeanTweenType _lean_type = LeanTweenType.easeInOutQuad;
        [SerializeField] private float _rotateTweenAngles = 360;
        [SerializeField] private float _rotateTweenTime = 2;
        [SerializeField] private float _localYTween = 0.5f;
        [SerializeField] private float _localYTweenTime = 1;

        private LevelPart _levelPart;

        public void Initialize(int lane, LevelPart levelPart)
        {
            _levelPart = levelPart;
            Initialize(lane);
        }

        public override void Initialize(int lane)
        {
            base.Initialize(lane);

            LTDescr rotateTween = LeanTween.rotateAround(gameObject, Vector3.up, _rotateTweenAngles, _rotateTweenTime);
            rotateTween.setRepeat(-1);

            LTDescr moveLocalYTween = LeanTween.moveLocalY(gameObject, transform.position.y + _localYTween, _localYTweenTime);
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

        private void Disable()
        {
            _levelPart.OnLevelDisable -= this.RetrieveToObjectPool;
            this.RetrieveToObjectPool();
        }

        protected override void CollidedWithPlayer()
        {
            GameEvent.CollectableCollision();
            Disable();
        }
    }
}
