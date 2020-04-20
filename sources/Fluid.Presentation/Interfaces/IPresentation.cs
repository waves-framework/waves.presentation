using System;
using System.ComponentModel;
using Fluid.Core.Base.Interfaces;

namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentations.
    /// </summary>
    public interface IPresentation : INotifyPropertyChanged, IDisposable
    {
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