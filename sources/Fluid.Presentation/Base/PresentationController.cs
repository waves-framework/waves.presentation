using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fluid.Core.Base;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    /// <summary>
    /// Abstract presentation controller base class.
    /// </summary>
    public abstract class PresentationController : ObservableObject, IPresentationController
    {
        private IPresentation _selectedPresentation;

        private ICollection<IPresentation> _presentations =
            new ObservableCollection<IPresentation>();

        /// <inheritdoc />
        public virtual IPresentation SelectedPresentation
        {
            get => _selectedPresentation;
            set
            {
                if (Equals(value, _selectedPresentation))
                {
                    return;
                }

                _selectedPresentation = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public ICollection<IPresentation> Presentations
        {
            get => _presentations;
            private set
            {
                if (Equals(value, _presentations))
                {
                    return;
                }

                _presentations = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public abstract void Initialize();
    }
}
