using System;
using System.ComponentModel;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentations.
    /// </summary>
    public interface IPresentation : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        ///     Gets whether presentation is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     Gets view model context.
        /// </summary>
        IPresentationViewModel DataContext { get; }

        /// <summary>
        ///     Gets view.
        /// </summary>
        IPresentationView View { get; }

        /// <summary>
        ///     Initializes presentation.
        /// </summary>
        void Initialize();
    }
}