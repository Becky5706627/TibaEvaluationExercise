using NUnit.Framework;

namespace TibaEvaluationExercise.Utilities
{
    public static class TestAssert
    {
        public static void AssertTrue(bool condition, string? message = null)
        {
            if (message == null) {
                message = $"Expected condition to be True, but it was not. condition: {condition}";
            }
            Assert.IsTrue(condition, message);
        }

        public static void AssertFalse(bool condition, string? message = null)
        {
            if (message == null) {
                message = $"Expected condition to be False, but it was not. condition: {condition}.";
            }
            Assert.IsFalse(condition, message);
        }

        public static void AssertEqual(object expected, object actual, string? message = null)
        {
            if (message == null)
            {
                message = $"Expected {expected}, but got {actual}.";
            }
            Assert.AreEqual(expected, actual, message);
        }
    }
}
