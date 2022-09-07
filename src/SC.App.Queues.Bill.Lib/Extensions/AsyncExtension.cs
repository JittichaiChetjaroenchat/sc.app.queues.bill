using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Lib.Extensions
{
    /// <summary>
    /// The async extension
    /// </summary>
    public static class AsyncExtension
    {
        /// <summary>
        /// Run sync
        /// </summary>
        /// <param name="task">The task</param>
        public static void RunSync(this Task task)
        {
            task
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Run sync
        /// </summary>
        /// <typeparam name="T">The type of result</typeparam>
        /// <param name="task">The task</param>
        /// <returns>The result</returns>
        public static T RunSync<T>(this Task<T> task)
        {
            return task
                .GetAwaiter()
                .GetResult();
        }
    }
}