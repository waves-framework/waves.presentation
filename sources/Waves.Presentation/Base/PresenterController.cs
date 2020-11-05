using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    ///     Abstract presenter controller base class.
    /// </summary>
    public abstract class PresenterController : Waves.Core.Base.Object, IPresenterController
    {
        private IPresenter _selectedPresenter;

        private ICollection<IPresenter> _presenters = new ObservableCollection<IPresenter>();

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
            try
            {
                presenter.MessageReceived += OnPresentationMessageReceived;

                presenter.Initialize();

                Presenters.Add(presenter);
                
                OnMessageReceived(
                    this,
                    new Message(
                        $"Registering presenter",
                        $"Presenter {presenter.Name} ({presenter.Id}) was registered with the controller {Name} ({Id})",
                        Name,
                        MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new Message(
                        "Registering presenter",
                        $"Error occured while registering {presenter.Name} ({presenter.Id})",
                        Name,
                        e,
                        false));
            }
        }

        /// <inheritdoc />
        public void UnregisterPresenter(IPresenter presenter)
        {
            try
            {
                presenter.Dispose();

                presenter.MessageReceived -= OnPresentationMessageReceived;

                Presenters.Remove(presenter);
                
                OnMessageReceived(
                    this,
                    new Message(
                        $"Unregistering presenter",
                        $"Presenter {presenter.Name} ({presenter.Id}) was unregistered from the controller {Name} ({Id})",
                        Name,
                        MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new Message(
                        $"Unregistering presenter",
                        $"Error occured while unregistering {presenter.Name} ({presenter.Id})",
                        Name,
                        e,
                        false));
            }
            
        }

        /// <summary>
        /// Actions when message received from presenter.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPresentationMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(sender,e);
        }
    }
}