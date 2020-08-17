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
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     Gets whether presentation is initialized.
        /// </summary>
        bool IsInitialized { get; }

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

        /// <summary>
        /// Sets presentation view.
        /// </summary>
        /// <param name="view">View.</param>
        void SetView(IPresentationView view);

        /// <summary>
        /// Sets data context.
        /// </summary>
        /// <param name="viewModel">View model.</param>
        void SetDataContext(IPresentationViewModel viewModel);
    }
}