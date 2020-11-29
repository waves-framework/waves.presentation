using System;
using ReactiveUI.Fody.Helpers;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.Presentation.Base
{
    /// <summary>
    ///     Abstract presenter base class.
    /// </summary>
    public abstract class Presenter : WavesObject, IPresenter
    {
        /// <summary>
        ///     Creates new instance of <see cref="Presenter" />.
        /// </summary>
        /// <param name="core">Instance of core.</param>
        protected Presenter(IWavesCore core)
        {
            Core = core
                   ?? throw new ArgumentNullException(
                       nameof(core),
                       "Presenter didn't receive core instance.");
        }

        /// <inheritdoc />
        public IWavesCore Core { get; protected set; }

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
                    DataContext.MessageReceived += OnMessageReceived;
                    DataContext.Initialize();
                }

                if (View != null)
                {
                    View.MessageReceived += OnMessageReceived;
                    View.DataContext = DataContext;
                    View.AttachCore(Core);
                }

                IsInitialized = CheckInitialization();

                var message = new WavesMessage(
                    "Presenter initialization",
                    $"Presenter {Name} ({Id}) was initialized.",
                    Name,
                    WavesMessageType.Information);

                OnMessageReceived(this, message);
            }
            catch (Exception e)
            {
                var message = new WavesMessage(
                    "Presenter initialization",
                    $"Error occured while initialization {Name} ({Id})",
                    Name,
                    e,
                    false);

                OnMessageReceived(this, message);
            }
        }

        /// <inheritdoc />
        public void SetView(IPresenterView view)
        {
            try
            {
                if (View != null) View.MessageReceived -= OnMessageReceived;

                View = view;

                if (View != null)
                {
                    View.MessageReceived += OnMessageReceived;
                    View.DataContext = DataContext;
                }

                IsInitialized = CheckInitialization();

                var message = new WavesMessage(
                    "Setting view",
                    $"View {view.Name} ({view.Id}) was set with the presenter {Name} ({Id}) ",
                    Name,
                    WavesMessageType.Information);

                OnMessageReceived(this, message);
            }
            catch (Exception e)
            {
                var message = new WavesMessage(
                    "Setting view",
                    $"Error occured while setting view {view.Name} ({view.Id}) on presenter {Name} ({Id})",
                    Name,
                    e,
                    false);

                OnMessageReceived(this, message);
            }
        }

        /// <inheritdoc />
        public void SetDataContext(IPresenterViewModel viewModel)
        {
            try
            {
                if (DataContext != null) DataContext.MessageReceived -= OnMessageReceived;

                DataContext = viewModel;

                if (DataContext != null)
                {
                    DataContext.MessageReceived += OnMessageReceived;
                    DataContext.Initialize();

                    if (View != null) View.DataContext = DataContext;
                }

                IsInitialized = CheckInitialization();

                var message = new WavesMessage(
                    "Setting view model",
                    $"View model {viewModel.Name} ({viewModel.Id}) was set with the presenter {Name} ({Id}) ",
                    Name,
                    WavesMessageType.Information);

                OnMessageReceived(this, message);
            }
            catch (Exception e)
            {
                var message = new WavesMessage(
                    "Setting view model",
                    $"Error occured while setting view model {viewModel.Name} ({viewModel.Id}) on presenter {Name} ({Id})",
                    Name,
                    e,
                    false);

                OnMessageReceived(this, message);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            UnsubscribeEvents();
        }

        /// <summary>
        ///     Unsubscribes from events.
        /// </summary>
        private void UnsubscribeEvents()
        {
            if (DataContext != null)
                DataContext.MessageReceived -= OnMessageReceived;

            if (View != null)
                View.MessageReceived -= OnMessageReceived;
        }

        /// <summary>
        ///     Checks presentation initialization status.
        /// </summary>
        /// <returns>Presentation initialization status.</returns>
        private bool CheckInitialization()
        {
            if (DataContext != null
                && View != null
                && View.DataContext.Equals(DataContext))
                return DataContext.IsInitialized;

            return false;
        }
    }
}