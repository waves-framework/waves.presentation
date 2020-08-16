using System;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    /// Abstract presentation base class.
    /// </summary>
    public abstract class Presentation : ObservableObject, IPresentation
    {
        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <inheritdoc />
        public virtual bool IsInitialized { get; private set; }

        /// <inheritdoc />
        public abstract IPresentationViewModel DataContext { get; protected set; }

        /// <inheritdoc />
        public abstract IPresentationView View { get; protected set; }

        /// <inheritdoc />
        public virtual void Initialize()
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
        }

        /// <inheritdoc />
        public void SetView(IPresentationView view)
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
        }

        /// <inheritdoc />
        public void SetDataContext(IPresentationViewModel viewModel)
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
        /// Actions when message received from data context.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataContextMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }

        /// <summary>
        /// Actions when message received from view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewMessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }

        /// <inheritdoc />
        public virtual void Dispose()
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
