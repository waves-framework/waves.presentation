﻿using Fluid.Core.Base;
using Fluid.Presentation.Interfaces;

namespace Fluid.Presentation.Base
{
    public abstract class Presentation : ObservableObject, IPresentation
    {
        /// <inheritdoc />
        public abstract IPresentationViewModel DataContext { get; }

        /// <inheritdoc />
        public abstract IPresentationView View { get; }

        /// <inheritdoc />
        public virtual void Initialize()
        {
            View.DataContext = DataContext;
        }
    }
}