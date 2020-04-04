using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Fluid.Presentation.Interfaces
{
    /// <summary>
    /// Interface for presentation controllers.
    /// </summary>
    public interface IPresentationController : INotifyPropertyChanged
    {
        /// <summary>
        ///     Gets or sets selected presentation.
        /// </summary>
        IPresentation SelectedPresentation { get; set; }

        /// <summary>
        ///     Gets presentations collection.
        /// </summary>
        ICollection<IPresentation> Presentations { get; }

        /// <summary>
        /// Initializes presentation controller.
        /// </summary>
        void Initialize();
    }
}