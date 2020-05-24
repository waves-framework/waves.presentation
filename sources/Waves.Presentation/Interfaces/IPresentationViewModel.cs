using System;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentation view models.
    /// </summary>
    public interface IPresentationViewModel : IObservableObject
    {
        /// <summary>
        ///     Gets whether presentation view model is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Initializes presentation view model.
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;
    }
}