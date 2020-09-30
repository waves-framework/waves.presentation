using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    ///     Abstract presenter controller base class.
    /// </summary>
    public abstract class PresenterController : ObservableObject, IPresenterController
    {
        private IPresenter _selectedPresenter;

        private ICollection<IPresenter> _presenters = new ObservableCollection<IPresenter>();

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <inheritdoc />
        [Reactive]
        public virtual IPresenter SelectedPresenter
        {
            get => _selectedPresenter;
            set => this.RaiseAndSetIfChanged(ref _selectedPresenter, value);
        }

        /// <inheritdoc />
        [Reactive]
        public ICollection<IPresenter> Presenters
        {
            get => _presenters;
            protected set => this.RaiseAndSetIfChanged(ref _presenters, value);
        }

        /// <inheritdoc />
        public abstract void Initialize();

        /// <inheritdoc />
        public void RegisterPresenter(IPresenter presenter)
        {
            presenter.MessageReceived += OnPresentationMessageReceived;

            presenter.Initialize();

            Presenters.Add(presenter);
        }

        /// <inheritdoc />
        public void UnregisterPresenter(IPresenter presenter)
        {
            presenter.Dispose();

            presenter.MessageReceived -= OnPresentationMessageReceived;

            Presenters.Remove(presenter);
        }

        /// <summary>
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Actions when message received from presenter.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPresentationMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }
    }
}