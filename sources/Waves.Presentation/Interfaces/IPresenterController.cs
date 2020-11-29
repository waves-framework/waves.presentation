using System;
using System.Collections.Generic;
using System.ComponentModel;
using Waves.Core.Base.Interfaces;

namespace Waves.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presenter controllers.
    /// </summary>
    public interface IPresenterController : IWavesObject
    {
        /// <summary>
        /// Get instance of core.
        /// </summary>
        IWavesCore Core { get; }
        
        /// <summary>
        ///     Gets or sets selected presenter.
        /// </summary>
        IPresenter SelectedPresenter { get; set; }

        /// <summary>
        ///     Gets presenters collection.
        /// </summary>
        ICollection<IPresenter> Presenters { get; }

        /// <summary>
        ///     Initializes presenter controller.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Registers presenter.
        /// </summary>
        /// <param name="presenter">Presenter.</param>
        void RegisterPresenter(IPresenter presenter);

        /// <summary>
        /// Unregisters presenter.
        /// </summary>
        /// <param name="presenter">Presenter.</param>
        void UnregisterPresenter(IPresenter presenter);
    }
}