using System;
using System.Collections.Generic;
using System.ComponentModel;
using Fluid.Core.Base.Interfaces;

namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    ///     Interface for presentation controllers.
    /// </summary>
    public interface IPresentationController : INotifyPropertyChanged
    {
        /// <summary>
        ///     Event for message received handling.
        /// </summary>
        event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     Gets or sets selected presentation.
        /// </summary>
        IPresentation SelectedPresentation { get; set; }

        /// <summary>
        ///     Gets presentations collection.
        /// </summary>
        ICollection<IPresentation> Presentations { get; }

        /// <summary>
        ///     Initializes presentation controller.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Registers presentation.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        void RegisterPresentation(IPresentation presentation);

        /// <summary>
        /// Unregisters presentation.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        void UnregisterPresentation(IPresentation presentation);
    }
}