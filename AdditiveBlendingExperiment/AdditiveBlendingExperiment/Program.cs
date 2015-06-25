using System;

namespace AdditiveBlendingExperiment
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (ColorsTest game = new ColorsTest())
            {
                game.Run();
            }
        }
    }
#endif
}

