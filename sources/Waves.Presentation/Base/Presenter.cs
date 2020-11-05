using System;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Object = System.Object;

namespace Waves.Presentation.Base
{
    /// <summary>
    /// Abstract presenter base class.
    /// </summary>
    public abstract class Presenter : Waves.Core.Base.Object, IPresenter
    {
        /// <inheritdoc />
        [Reactive]
        public virtual bool IsInitialized { get; private set; }

        /// <inheritdoc />
        [Reactive]
        public virtual IPresenterViewModel DataContext { get; protected set; }

        /// <inheritdoc />
        [Reactive]
        public virtual IPresenterView View { get; protected set; }

        /// <inheritdoc />
        public virtual void Initialize()
        {
            try
            {
                if (DataContext != null)
                {
                    DataContext.MessageReceived += OnDataContextMessageReceived;
                    DataContext.Initialize();
                }

                if (View != null)
                {
                    View.MessageReceived += OnViewMessageReceived;
                    View.DataContext = DataContext;
                }

                IsInitialized = CheckInitialization();
                
                OnMessageReceived(
                    this,
                    new Message(
                        "Presenter initialization",
                        $"Presenter {Name} ({Id}) was initialized.",
                        Name,
                        MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new Message(
                        "Presenter initialization",
                        $"Error occured while initialization {Name} ({Id})",
                        Name,
                        e,
                        false));
            }
            
        }

        /// <inheritdoc />
        public void SetView(IPresenterView view)
        {
            try
            {
                if (View != null)
                {
                    View.MessageReceived -= OnViewMessageReceived;
                }

                View = view;

                if (View != null)
                {
                    View.MessageReceived += OnViewMessageReceived;
                    View.DataContext = DataContext;
                }

                IsInitialized = CheckInitialization();
                
                OnMessageReceived(
                    this,
                    new Message(
                        "Setting view",
                        $"View {view.Name} ({view.Id}) was set with the presenter {Name} ({Id}) ",
                        Name,
                        MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new Message(
                        "Setting view",
                        $"Error occured while setting view {view.Name} ({view.Id}) on presenter {Name} ({Id})",
                        Name,
                        e,
                        false));
            }
        }

        /// <inheritdoc />
        public void SetDataContext(IPresenterViewModel viewModel)
        {
            try
            {
                if (DataContext != null)
                {
                    DataContext.MessageReceived -= OnDataContextMessageReceived;
                }

                DataContext = viewModel;

                if (DataContext != null)
                {
                    DataContext.MessageReceived += OnDataContextMessageReceived;
                    DataContext.Initialize();

                    if (View != null)
                    {
                        View.DataContext = DataContext;
                    }
                }

                IsInitialized = CheckInitialization();
                
                OnMessageReceived(
                    this,
                    new Message(
                        "Setting view model",
                        $"View model {viewModel.Name} ({viewModel.Id}) was set with the presenter {Name} ({Id}) ",
                        Name,
                        MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(
                    this,
                    new Message(
                        "Setting view model",
                        $"Error occured while setting view model {viewModel.Name} ({viewModel.Id}) on presenter {Name} ({Id})",
                        Name,
                        e,
                        false));
            }
        }

        /// <summary>
        /// Actions when message received from data context.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Message.</param>
        private void OnDataContextMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(sender, e);
        }

        /// <summary>
        /// Actions when message received from view.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Message.</param>
        private void OnViewMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(sender,e);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            UnsubscribeEvents();
        }

        /// <summary>
        /// Unsubscribes from events.
        /// </summary>
        private void UnsubscribeEvents()
        {
            if (DataContext != null)
                DataContext.MessageReceived -= OnDataContextMessageReceived;

            if (View != null) 
                View.MessageReceived -= OnViewMessageReceived;
        }

        /// <summary>
        /// Checks presentation initialization status.
        /// </summary>
        /// <returns>Presentation initialization status.</returns>
        private bool CheckInitialization()
        {
            if (DataContext != null && View != null)
            {
                return DataContext.IsInitialized;
            }

            return false;
        }
    }
}
