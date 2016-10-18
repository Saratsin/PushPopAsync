using System;
using System.Threading;
using System.Threading.Tasks;

namespace PushPopAsync
{
	public static class IsBusyHandler
	{
		private static object _locker = new object ();
		public static bool IsBusy { get; private set; }

		public static void Handle (Action operation)
		{
			lock(_locker) {
				if (IsBusy) {
					return;
				}
				try {
					IsBusy = true;
					operation ();
				} catch (Exception) {
					//TODO Handle exception on button click here

				} finally {
					IsBusy = false;
				}
			}
		}

		public static async Task Handle (Func<Task> operation)
		{
			//TODO Good way to show loading spinner on the screen and then remove it
            if (IsBusy)
            {
                System.Diagnostics.Debug.WriteLine("Task is busy");
                return;
            }
            IsBusy = true;
            System.Diagnostics.Debug.WriteLine("Task become busy");           

            try
            {
                    await operation();
			} catch (Exception) {
				//TODO Handle exception on button click here

			} finally {
				IsBusy = false;
                System.Diagnostics.Debug.WriteLine("Task is not busy now");
			}
		}
	}
}
