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
    public abstract class PresenterController : Waves.Core.Base.WavesObject, IPresenterController
    {
        private IPresenter _selectedPresenter;

        private ICollection<IPresenter> _presenters = new ObservableCollection<IPresenter>();
        
        /// <summary>
        /// Creates new instance of <see cref="PresenterController"/>.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        protected PresenterController(IWavesCore core)
        {
            Core = core;
        }
        
        /// <inheritdoc />
        public IWavesCore Core { get; }

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
                presenter.MessageReceived += OnMessageReceived;

                presenter.Initialize();

                Presenters.Add(presenter);

                var message = new WavesMessage(
                    $"Registering presenter",
                    $"Presenter {presenter.Name} ({presenter.Id}) was registered with the controller {Name} ({Id})",
                    Name,
                    WavesMessageType.Information);

                OnMessageReceived(this, message);
            }
            catch (Exception e)
            {
                var message = new WavesMessage(
                    "Registering presenter",
                    $"Error occured while registering {presenter.Name} ({presenter.Id})",
                    Name,
                    e,
                    false);
                
                OnMessageReceived(this, message);
            }
        }

        /// <inheritdoc />
        public void UnregisterPresenter(IPresenter presenter)
        {
            try
            {
                presenter.Dispose();

                presenter.MessageReceived -= OnMessageReceived;

                Presenters.Remove(presenter);

                var message = new WavesMessage(
                    $"Unregistering presenter",
                    $"Presenter {presenter.Name} ({presenter.Id}) was unregistered from the controller {Name} ({Id})",
                    Name,
                    WavesMessageType.Information);
                
                OnMessageReceived(this, message);
            }
            catch (Exception e)
            {
                var message = new WavesMessage(
                    $"Unregistering presenter",
                    $"Error occured while unregistering {presenter.Name} ({presenter.Id})",
                    Name,
                    e,
                    false);
                
                OnMessageReceived(this, message);
            }
            
        }
    }
}