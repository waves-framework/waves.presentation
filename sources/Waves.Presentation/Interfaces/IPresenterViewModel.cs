using System;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presenter view models.
    /// </summary>
    public interface IPresenterViewModel : IWavesObject
    {
        /// <summary>
        /// Get instance of core.
        /// </summary>
        IWavesCore Core { get; }
        
        /// <summary>
        ///     Gets whether presenter view model is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Initializes presenter view model.
        /// </summary>
        void Initialize();
    }
}