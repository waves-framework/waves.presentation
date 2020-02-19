using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Fluid.Presentation.Interfaces
{
    public interface IPresentationController : INotifyPropertyChanged
    {
        /// <summary>
        ///     Выбранное представление.
        /// </summary>
        IPresentation SelectedPresentation { get; set; }

        /// <summary>
        ///     Список доступных представлений.
        /// </summary>
        ObservableCollection<IPresentation> Presentations { get; }

        /// <summary>
        /// Инициализация.
        /// </summary>
        void Initialize();
    }
}