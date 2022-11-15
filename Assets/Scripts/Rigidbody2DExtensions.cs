using UnityEngine;

public static class Rigidbody2DExtensions
{
    /// <summary>
    /// Move towards a target position with velocity.
    /// This supports dampening.
    /// </summary>
    /// <param name="rigidbody2D">The rigidbody being controlled.</param>
    /// <param name="targetPosition">The target position to move towards.</param>
    /// <param name="speed">The speed with which we will move towards the target.</param>
    /// <param name="dampenMovement">Whether we should smoothly damp the movement towards the target.</param>
    public static void MoveTowardsWithVelocity(this Rigidbody2D rigidbody2D, Vector2 targetPosition, float speed, bool dampenMovement = false)
    {
        Vector2 position = rigidbody2D.transform.position;
        var difference = targetPosition - position;

        if (!dampenMovement)
        {
            difference.Normalize();
        }

        rigidbody2D.velocity = difference * speed;
    }

    /// <summary>
    /// Move towards a target position by smothly changing velocity.
    /// Will use regular speed for smoothing if no smoothingSpeed is provided.
    /// </summary>
    /// <param name="rigidbody2D">The rigidbody being controlled.</param>
    /// <param name="targetPosition">The target position to move towards.</param>
    /// <param name="speed">The speed with which we will move towards the target.</param>
    /// <param name="smoothingSpeed">The speed with which the old velocity will change to the new.</param>
    public static void SmoothlyMoveTowardsWithVelocity(this Rigidbody2D rigidbody2D, Vector2 targetPosition, float speed, float smoothingSpeed = -1f)
    {
        if (smoothingSpeed <= 0f)
        {
            smoothingSpeed = speed;
        }

        Vector2 position = rigidbody2D.transform.position;
        var difference = targetPosition - position;
        difference.Normalize();

        var newVelocity = difference * speed;
        rigidbody2D.velocity = Vector2.MoveTowards(rigidbody2D.velocity, newVelocity, smoothingSpeed);
    }
}