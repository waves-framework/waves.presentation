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
        public virtual bool IsInitialized { get; private set; }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <inheritdoc />
        public abstract IPresentationViewModel DataContext { get; protected set; }

        /// <inheritdoc />
        public abstract IPresentationView View { get; protected set; }

        /// <inheritdoc />
        public virtual void Initialize()
        {
            if (DataContext != null && View != null)
            {
                DataContext.MessageReceived += OnDataContextMessageReceived;

                if (View != null)
                    View.MessageReceived += View_MessageReceived;

                View.DataContext = DataContext;

                DataContext.Initialize();

                IsInitialized = true;
            }
            else
            {
                IsInitialized = false;
            }
        }

        /// <inheritdoc />
        public void SetView(IPresentationView view)
        {
            UnsubscribeEvents();

            View = view;

            Initialize();
        }

        /// <inheritdoc />
        public void SetDataContext(IPresentationViewModel viewModel)
        {
            UnsubscribeEvents();

            DataContext = viewModel;

            Initialize();
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
        private void View_MessageReceived(object sender, IMessage e)
        {
            OnMessageReceived(e);
        }

        /// <inheritdoc />
        public virtual void Dispose()
        {
            UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            DataContext.MessageReceived -= OnDataContextMessageReceived;
            View.MessageReceived -= View_MessageReceived;
        }
    }
}
