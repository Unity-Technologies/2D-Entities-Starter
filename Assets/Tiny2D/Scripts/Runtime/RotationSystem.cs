using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Tiny2D
{
    public class RotationSystem : JobComponentSystem 
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var deltaTime = Time.DeltaTime;
            inputDeps = Entities.ForEach((
                Entity e,
                ref Rotation rotation,
                in RotationSpeed rotationSpeed) =>
            {
                var rotationAmount = quaternion.RotateZ(rotationSpeed.Value * deltaTime);
                rotation.Value = math.mul(rotation.Value, rotationAmount);
                
            }).Schedule(inputDeps);
            return inputDeps;
        }
    }
}