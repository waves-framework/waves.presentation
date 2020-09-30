using System;
using System.ComponentModel;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presenters.
    /// </summary>
    public interface IPresenter : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     Gets whether presenter is initialized.
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Gets view model context.
        /// </summary>
        IPresenterViewModel DataContext { get; }

        /// <summary>
        ///     Gets view.
        /// </summary>
        IPresenterView View { get; }

        /// <summary>
        ///     Initializes presenter.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Sets presenter view.
        /// </summary>
        /// <param name="view">View.</param>
        void SetView(IPresenterView view);

        /// <summary>
        /// Sets data context.
        /// </summary>
        /// <param name="viewModel">View model.</param>
        void SetDataContext(IPresenterViewModel viewModel);
    }
}